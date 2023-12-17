using eGym.Helper;
using Microsoft.AspNetCore.Mvc;

namespace eGym.Data.Controllers.Admin.Obrisi
{
    [Tags("Admin")]
    public class AdminObrisiEndpoint : MyBaseEndpoint<AdminObrisiRequest,AdminObrisiResponse>
    {
        public readonly ApplicationDbContext _applicationDbContext;
        public AdminObrisiEndpoint (ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpDelete]
        public override async Task<AdminObrisiResponse> Obradi([FromQuery]AdminObrisiRequest request, CancellationToken cancellationToken)
        {
            var admini = _applicationDbContext.Admin.FirstOrDefault(x => x.ID == request.AdminID);
            if(admini == null)
            {
                throw new Exception("Nije pronadjen admin za id= " + request.AdminID);
            }
            _applicationDbContext.Remove(admini);
            await _applicationDbContext.SaveChangesAsync();
            return new AdminObrisiResponse
            {

            };
        }
    }
}
