using eGym.Data.Helpers.Services;
using eGym.Data.Models;
using eGym.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace eGym.Data.Endpoints.RadnikEndpoints.Dodaj
{
    [Tags("Radnik")]
    public class RadnikDodajEndpoint : MyBaseEndpoint<RadnikDodajRequest, RadnikDodajResponse>
    {
        private readonly ApplicationDbContext _context;
        private readonly MyAuthService _authService;
        public RadnikDodajEndpoint(ApplicationDbContext context, MyAuthService authService)
        {
            _context = context;
            _authService = authService;
        }
        [HttpPost]
        public override async Task<RadnikDodajResponse> Obradi([FromBody]RadnikDodajRequest request, CancellationToken cancellationToken)
        {
            if (!(_authService.isLogiran() && _authService.isAdmin()))
                throw new Exception("Korisnik nema permisiju admina ili nije logiran");
            var noviRadnik = new Radnik
            {
                Ime = request.Ime,
                Prezime = request.Prezime,
                DatumRodjenja = request.DatumRodjenja,
                BrojTelefona = request.BrojTelefona,
                DatumZaposlenja = request.DatumZaposlenja,
                GradID = request.GradID,
                Spol = request.Spol,
                KorisnikID = request.KorisnikID
            };
            var provjeraDuplikata = _context.Radnik.Where(r => r.KorisnikID == noviRadnik.KorisnikID).FirstOrDefault();
            if(provjeraDuplikata != null){
                throw new Exception("Radnik vec postoji u bazi");
            }
            _context.Radnik.Add(noviRadnik);
            await _context.SaveChangesAsync();
            return new RadnikDodajResponse
            {

            };
        }
    }
}
