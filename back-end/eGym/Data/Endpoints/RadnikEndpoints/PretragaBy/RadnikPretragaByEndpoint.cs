using eGym.Data.Helpers.Services;
using eGym.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static eGym.Data.Endpoints.RadnikEndpoints.PretragaBy.RadnikPretragaByResponse;

namespace eGym.Data.Endpoints.RadnikEndpoints.PretragaBy
{
    [Tags("Radnik")]
    public class RadnikPretragaByEndpoint : MyBaseEndpoint<RadnikPretragaByRequest, RadnikPretragaByResponse>
    {
        private readonly ApplicationDbContext _context;
        private readonly MyAuthService _authService;

        public RadnikPretragaByEndpoint(ApplicationDbContext context, MyAuthService authService)
        {
            _context = context;
            _authService = authService;
        }
        [HttpGet]
        public override async Task<RadnikPretragaByResponse> Obradi([FromQuery]RadnikPretragaByRequest request, CancellationToken cancellationToken)
        {
            if (!(_authService.isLogiran() && (_authService.isAdmin() ||_authService.isRadnik())))
                throw new Exception("Korisnik nema permisiju admina ili nije logiran");
            var odabraniRadnik = await _context.Radnik.Where(r => r.KorisnikID == request.KorisnickiNalogID).
                Select(x => new RadnikPretragaByResponseRadnik()
                {
                    Ime = x.Ime,
                    Prezime = x.Prezime,
                    DatumZaposlenja = DateOnly.FromDateTime(x.DatumZaposlenja),
                    Spol = x.Spol
                }).ToListAsync();

            return new RadnikPretragaByResponse
            {
                Radnik = odabraniRadnik
            };
        }
    }
}
