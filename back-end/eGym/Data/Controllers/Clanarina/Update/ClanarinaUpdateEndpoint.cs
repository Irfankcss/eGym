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
            DateTime izracunatiDatum = DateTime.Now;
            clanarina.DatumUplate = DateTime.Now;
            clanarina.DatumIsteka = izracunatiDatum.AddDays(30);
            await _applicationDbContext.SaveChangesAsync();
            return new ClanarinaUpdateResponse
            {
                ClanarinaID = clanarina.ID,
                DatumUplate = clanarina.DatumUplate,
                DatumIsteka = clanarina.DatumIsteka
            };
        }
    }
}
