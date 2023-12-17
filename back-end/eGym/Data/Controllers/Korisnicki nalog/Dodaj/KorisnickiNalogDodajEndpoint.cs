using eGym.Helper;
using Microsoft.AspNetCore.Mvc;

namespace eGym.Data.Controllers.Korisnicki_nalog.Dodaj
{
    [Tags("Korisnicki-nalog")]
    public class KorisnickiNalogDodajEndpoint : MyBaseEndpoint <KorisnickiNalogDodajRequest,KorisnickiNalogDodajResponse>
    {
        public readonly ApplicationDbContext _applicationDbContext;

        public KorisnickiNalogDodajEndpoint (ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpPost]
        public override async Task<KorisnickiNalogDodajResponse> Obradi([FromBody]KorisnickiNalogDodajRequest request, CancellationToken cancellationToken)
        {
            var noviObj = new Data.Models.KorisnickiNalog
            {
                KorisnickoIme = request.KorisnickoIme,
                Email = request.Email,
                Lozinka = request.Lozinka,
                Slika = request.Slika,
                isAdmin = request.isAdmin,
                isKorisnik = request.isKorisnik,
                isRadnik = request.isRadnik
            };
            _applicationDbContext.Add(noviObj);
            await _applicationDbContext.SaveChangesAsync();
            return new KorisnickiNalogDodajResponse
            {
                KorisnickiNalogID = noviObj.ID
            };
        }
    }
}
