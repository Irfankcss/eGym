using eGym.Helper;
using Microsoft.AspNetCore.Mvc;

namespace eGym.Data.Controllers.Clanarina.Dodaj
{
    [Tags("Clanarina")]
    public class ClanarinaDodajEndpoint : MyBaseEndpoint<ClanarinaDodajRequest,ClanarinaDodajResponse>
    {
        public readonly ApplicationDbContext _applicationDbContext;
        public ClanarinaDodajEndpoint (ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpPost]
        public override async Task<ClanarinaDodajResponse> Obradi([FromBody]ClanarinaDodajRequest request, CancellationToken cancellationToken)
        {
            var noviObj = new Data.Models.Clanarina
            {
                DatumUplate = request.DatumUplate,
                DatumIsteka = request.DatumIsteka
            };
            _applicationDbContext.Add(noviObj);
            await _applicationDbContext.SaveChangesAsync();
            return new ClanarinaDodajResponse
            {
                ClanarinaID = noviObj.ID
            };
        }
    }
}
