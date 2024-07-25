using eGym.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Identity.Client;

namespace eGym.Data.Controllers.Korisnik.Dodaj
{
    [Tags("Korisnik")]
    public class KorisnikDodajEndpoint : MyBaseEndpoint<KorisnikDodajRequest, KorisnikDodajResponse>
    {
        public readonly ApplicationDbContext _applicationDbContext;
        public KorisnikDodajEndpoint (ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpPost]
        public override async Task<KorisnikDodajResponse> Obradi([FromBody]KorisnikDodajRequest request, CancellationToken cancellationToken)
        {
            var noviObj = new Data.Models.Korisnik {
                //ID = request.ID,
                Ime = request.Ime,
                Prezime = request.Prezime,
                OpstinaRodjenjaID = request.OpstinaRodjenjaID,
                DatumRodjenja = request.DatumRodjenja,
                BrojTelefona = request.BrojTelefona,
                Spol = request.Spol,
                Email = request.Email,
                isAdmin = false,
                isKorisnik = true,
                isRadnik = false,
                KorisnickoIme = request.KorisnickoIme,
                Lozinka = request.Lozinka,
                isClan = false
            };
            _applicationDbContext.Add(noviObj);
            await _applicationDbContext.SaveChangesAsync();

            return new KorisnikDodajResponse
            {
                KorisnikID = noviObj.ID,
            };
        }
    }
}
