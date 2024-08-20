using eGym.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eGym.Data.Controllers.Korisnicki_nalog.Pretraga
{
    [Tags("Korisnicki-nalog")]
    public class KorisnickiNalogPretragaEndpoint : MyBaseEndpoint<KorisnickiNalogPretragaRequest, KorisnickiNalogPretragaResponse>
    {
        public readonly ApplicationDbContext _applicationDbContext;
        public KorisnickiNalogPretragaEndpoint (ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        public override async Task<KorisnickiNalogPretragaResponse> Obradi([FromQuery] KorisnickiNalogPretragaRequest request, CancellationToken cancellationToken)
        {
            var korisnickiNalozi = await _applicationDbContext.KorisnickiNalog
                .Select(x => new KorisnickiNalogPretragaResponseKorisnickiNalog
                {
                    ID = x.ID,
                    KorisnickoIme = x.KorisnickoIme,
                    Email = x.Email,
                    Lozinka = x.Lozinka,
                    Slika = x.Slika,
                    isAdmin = x.isAdmin,
                    isKorisnik = x.isKorisnik,
                    isRadnik = x.isRadnik,
                    isClan = x.isClan
                }).ToListAsync();
            return new KorisnickiNalogPretragaResponse
            {
                KorisnickiNalozi = korisnickiNalozi
            };
        }
    }
}
