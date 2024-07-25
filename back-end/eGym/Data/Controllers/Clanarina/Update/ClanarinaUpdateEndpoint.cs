using eGym.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace eGym.Data.Controllers.Clanarina.Update
{
    [Tags("Clanarina")]
    public class ClanarinaUpdateEndpoint : MyBaseEndpoint<ClanarinaUpdateRequest,ClanarinaUpdateResponse>
    {
        public readonly ApplicationDbContext _applicationDbContext;
        public ClanarinaUpdateEndpoint (ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpPost]
        public override async Task<ClanarinaUpdateResponse> Obradi([FromBody]ClanarinaUpdateRequest request, CancellationToken cancellationToken)
        {
            var clanarina = _applicationDbContext.Clanarina.FirstOrDefault(x=>x.ID == request.ClanarinaId);
            if (clanarina == null)
            {
                throw new Exception("Nema clanarine za id= " + request.ClanarinaId);
            }
            clanarina.DatumUplate = request.DatumUplate;
            clanarina.DatumIsteka = request.DatumIsteka;
            await _applicationDbContext.SaveChangesAsync();
            return new ClanarinaUpdateResponse
            {
                ClanarinaID = request.ClanarinaId
            };
        }
    }
}
