using eGym.Data.Controllers.ProizvodStatus.UpdateON;
using eGym.Data.Helpers.Services;
using eGym.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace eGym.Data.Controllers.ProizvodStatus.UpdateOFF
{
    [Tags("ProizvodStatus")]
    public class ProizvodiStatusUpdateOFFEndpoint : MyBaseEndpoint<ProizvodiStatusUpdateOFFRequest, ProizvodiStatusUpdateOFFResponse>
    {
        public readonly ApplicationDbContext _applicationDbContext;
        public readonly MyAuthService _authService;
        public ProizvodiStatusUpdateOFFEndpoint(ApplicationDbContext applicationDbContext,MyAuthService authService)
        {
            _applicationDbContext = applicationDbContext;
            _authService = authService;
        }
        [HttpPost]

        public override async Task<ProizvodiStatusUpdateOFFResponse> Obradi([FromQuery]ProizvodiStatusUpdateOFFRequest request, CancellationToken cancellationToken)
        {
            if (!(_authService.isAdmin() && _authService.isLogiran()))
                throw new Exception("Korisnik nema permisiju admina ili nije logiran");

            var proizvod = _applicationDbContext.Proizvod.Where(x => request.ProizvodID == x.ProizvodID).FirstOrDefault();
            if (proizvod == null)
            {
                throw new Exception("Proizvod nije pronađen za id: " + request.ProizvodID);
            }
            proizvod.isIzdvojen = false;
            await _applicationDbContext.SaveChangesAsync();
            return new ProizvodiStatusUpdateOFFResponse
            {
                ProizvodID = request.ProizvodID
            };
        }
    }
}
