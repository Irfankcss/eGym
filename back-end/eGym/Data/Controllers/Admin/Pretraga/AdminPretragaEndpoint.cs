using eGym.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eGym.Data.Controllers.Admin.Pretraga
{
    [Tags("Admin")]
    public class AdminPretragaEndpoint : MyBaseEndpoint<AdminPretragaRequest, AdminPretragaResponse>
    {
        public readonly ApplicationDbContext _applicationDbContext;
        public AdminPretragaEndpoint (ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        public override async Task<AdminPretragaResponse> Obradi([FromQuery] AdminPretragaRequest request, CancellationToken cancellationToken)
        {
            var admini = await _applicationDbContext
                .Admin
                .Select(x => new AdminPretragaResponseAdmin
                {
                    ID = x.ID,
                    AdminKod = x.AdminKod
                }).ToListAsync();
            return new AdminPretragaResponse
            {
                Admini = admini
            };
        }
    }
}
