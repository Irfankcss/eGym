using eGym.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eGym.Data.Endpoints.Korisnik.Pretraga
{
    [Tags("Korisnik")]
    public class KorisnikPretragaEndpoint : MyBaseEndpoint<KorisnikPretragaRequest, KorisnikPetragaResponse>
    {
        public readonly ApplicationDbContext _applicationDbContext;

        public KorisnikPretragaEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        public override async Task<KorisnikPetragaResponse> Obradi([FromQuery] KorisnikPretragaRequest request, CancellationToken cancellationToken)
        {
            var korisnici = await _applicationDbContext.Korisnik.
                Select(x => new KorisnikPetragaResponseKorisnik
                {
                    ID = x.ID,
                    Ime = x.Ime,
                    Prezime = x.Prezime,
                    isClan = x.isClan,
                    //OpstinaRodjenja = x.OpstinaRodjenja.Naziv,
                    //DatumRodjenja = x.DatumRodjenja,
                    BrojTelefona = x.BrojTelefona,
                    Spol = x.Spol
                }).ToListAsync();
            return new KorisnikPetragaResponse
            {
                Korisnici = korisnici
            };
        }
    }
}
