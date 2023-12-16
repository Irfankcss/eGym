using eGym.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eGym.Data.Controllers.Kreditna_kartica.Pretrazi
{
    [Tags("Kreditna-kartica")]
    public class KreditnaKarticaPretraziEndpoint : MyBaseEndpoint<KredtinaKarticaPretraziRequest,KreditnaKarticaPretraziResponse>
    {
        public readonly ApplicationDbContext _applicationDbContext;
        public KreditnaKarticaPretraziEndpoint (ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        public override async Task<KreditnaKarticaPretraziResponse> Obradi([FromQuery]KredtinaKarticaPretraziRequest request, CancellationToken cancellationToken)
        {
            var kartice = await _applicationDbContext.KreditnaKartica
                .Select(x => new KreditnaKarticaPretraziResponseKreditnaKartica
                {
                    BrojKartice = x.BrojKartice,
                    DatumIsteka = x.DatumIsteka,
                    SigurnosniBroj = x.SigurnosniBroj,
                    TipKartice = x.TipKartice,
                    KorisnikID = x.KorisnikID

                }).ToListAsync();

            return new KreditnaKarticaPretraziResponse
            {
                kartice = kartice,
            };
        }
    }
}
