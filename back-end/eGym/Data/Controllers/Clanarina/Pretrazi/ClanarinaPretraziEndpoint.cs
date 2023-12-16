using eGym.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace eGym.Data.Controllers.Clanarina.Pretrazi
{
    [Tags("Clanarina")]
    public class ClanarinaPretraziEndpoint : MyBaseEndpoint<ClanarinaPretraziRequest,ClanarinaPretraziResponse>
    {
        public readonly ApplicationDbContext _applicationDbContext;
        public ClanarinaPretraziEndpoint (ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        public override async Task<ClanarinaPretraziResponse> Obradi([FromQuery]ClanarinaPretraziRequest request, CancellationToken cancellationToken)
        {
            var clanarine = await _applicationDbContext.Clanarina.
                Select(x => new ClanarinaPretraziResponseClanarina
                {
                    ClanarinaID = x.ID,
                    DatumUplate = x.DatumUplate,
                    DatumIsteka = x.DatumIsteka
                }).ToListAsync();
            await _applicationDbContext.SaveChangesAsync();
            return new ClanarinaPretraziResponse
            {
                Clanarina = clanarine
            };
        }
    }
}
