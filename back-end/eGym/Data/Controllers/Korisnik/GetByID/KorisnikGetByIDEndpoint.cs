using eGym.Data.Controllers.Korisnik.Pretraga;
using eGym.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eGym.Data.Controllers.Korisnik.GetByID
{
    [Tags("Korisnik")]
    public class KorisnikGetByIDEndpoint : MyBaseEndpoint<int, KorisnikGetByIDResponse>
    {
        public readonly ApplicationDbContext _applicationDbContext;

        public KorisnikGetByIDEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        public override async Task<KorisnikGetByIDResponse> Obradi([FromQuery] int ID, CancellationToken cancellationToken)
        {
            var korisnik = await _applicationDbContext.Korisnik.FirstOrDefaultAsync(x => x.ID == ID);
            if (korisnik == null)
            {
                return new KorisnikGetByIDResponse {
                    id = 0, 
                    Ime = null,
                    Prezime = null,
                    BrojTelefona = null,
                    DatumRodjenja = DateTime.Now,
                    OpstinaID = 0,
                    Spol = null,
                };
            }
            var response = new KorisnikGetByIDResponse
            {
                id = korisnik.ID,
                Ime = korisnik.Ime,
                Prezime = korisnik.Prezime,
                BrojTelefona = korisnik.BrojTelefona,
                DatumRodjenja = korisnik.DatumRodjenja,
                OpstinaID = korisnik.OpstinaRodjenjaID,
                Spol = korisnik.Spol,
            };
            return response;
        }
    }
}
