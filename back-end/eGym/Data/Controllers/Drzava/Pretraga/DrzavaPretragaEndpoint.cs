using eGym.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eGym.Data.Controllers.Drzava.Pretraga
{
    [Tags("Drzava")]
    public class DrzavaPretragaEndpoint : MyBaseEndpoint<DrzavaPretragaRequest, DrzavaPretragaResponse>
    {
        public readonly ApplicationDbContext _applicationDbContext;
        public DrzavaPretragaEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        public override async Task<DrzavaPretragaResponse> Obradi([FromQuery]DrzavaPretragaRequest request, CancellationToken cancellationToken)
        {
            var drzave = await _applicationDbContext.Drzava.
                Select(x => new DrzavaPretragaResponseDrzava
                {
                    ID = x.ID,
                    Naziv = x.Naziv,
                    Skracenica = x.Skracenica
                }).ToListAsync();
            return new DrzavaPretragaResponse
            {
                Drzave = drzave
            };
        }
    }
}
