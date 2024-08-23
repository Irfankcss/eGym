using eGym.Data.Helpers;
using eGym.Data.Helpers.Services;
using eGym.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace eGym.Data.Endpoints.RadnikEndpoints.Obrisi
{
    [Tags("Radnik")]
    public class RadnikObrisiEndpoint : MyBaseEndpoint<RadnikObrisiRequest, NoResponse>
    {
        private readonly ApplicationDbContext _context;
        private readonly MyAuthService _authService;
        public RadnikObrisiEndpoint(ApplicationDbContext context, MyAuthService authService)
        {
            _context = context;
            _authService = authService;
        }
        [HttpDelete]
        public override async Task<NoResponse> Obradi([FromQuery]RadnikObrisiRequest request, CancellationToken cancellationToken)
        {
            if (!(_authService.isLogiran() && _authService.isAdmin()))
                throw new Exception("Korisnik nema permisiju admina ili nije logiran");

            var odabraniRadnik = _context.Radnik.Where(r => r.KorisnikID == request.RadnikID).FirstOrDefault();
            if(odabraniRadnik != null)
                _context.Radnik.Remove(odabraniRadnik);

            var odabraniKorisnickiNalog = _context.Korisnik.Where(k=>k.ID== request.RadnikID).FirstOrDefault();
            if (odabraniKorisnickiNalog != null)
                _context.Korisnik.Remove(odabraniKorisnickiNalog);

            await _context.SaveChangesAsync();
            return new NoResponse
            {

            };
        }
    }
}
