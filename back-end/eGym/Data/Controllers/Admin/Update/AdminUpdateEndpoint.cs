using eGym.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace eGym.Data.Controllers.Admin.Update
{
    [Tags("Admin")]
    public class AdminUpdateEndpoint : MyBaseEndpoint<AdminUpdateRequest,AdminUpdateResponse>
    {
        public readonly ApplicationDbContext _applicationDbContext;

        public AdminUpdateEndpoint (ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpPost]
        public override async Task<AdminUpdateResponse> Obradi([FromBody]AdminUpdateRequest request, CancellationToken cancellationToken)
        {
            var admin = _applicationDbContext.Admin.FirstOrDefault(x => x.ID == request.AdminID);
            if(admin == null)
            {
                throw new Exception("Ne postoji admin za id= " + request.AdminID);
            }
            admin.AdminKod = request.AdminKod;
            await _applicationDbContext.SaveChangesAsync();

            return new AdminUpdateResponse
            {
               AdminID = request.AdminID
            };
        }
    }
}
