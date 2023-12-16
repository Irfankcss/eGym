using eGym.Helper;
using Microsoft.AspNetCore.Mvc;

namespace eGym.Data.Controllers.Kreditna_kartica.Dodaj
{
    [Tags("Kreditna-kartica")]
    public class KreditnaKarticaDodajEndpoint : MyBaseEndpoint<KreditnaKarticaDodajRequest,KreditnaKarticaDodajResponse>
    {
        public readonly ApplicationDbContext _applicationDbContext;
        public  KreditnaKarticaDodajEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpPost]
        public override async Task<KreditnaKarticaDodajResponse> Obradi([FromBody]KreditnaKarticaDodajRequest request, CancellationToken cancellationToken)
        {
            var noviObj = new Data.Models.KreditnaKartica
            {
                BrojKartice = request.BrojKartice,
                DatumIsteka = request.DatumIsteka,
                SigurnosniBroj = request.SigurnosniBroj,
                TipKartice = request.TipKartice,
                KorisnikID = request.KorisnikID
            };
            _applicationDbContext.Add(noviObj);
            await _applicationDbContext.SaveChangesAsync();
            return new KreditnaKarticaDodajResponse
            {
                KreditnaKarticaID = noviObj.ID
            };
        }
    }
}
