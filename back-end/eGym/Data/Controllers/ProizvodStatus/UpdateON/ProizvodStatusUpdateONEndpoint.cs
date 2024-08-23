using eGym.Data.Controllers.Obavijesti.Update;
using eGym.Data.Helpers.Services;
using eGym.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace eGym.Data.Controllers.ProizvodStatus.UpdateON
{
    [Tags("ProizvodStatus")]
    public class ProizvodStatusUpdateONEndpoint : MyBaseEndpoint<ProizvodStatusUpdateONRequest, ProizvodStatusUpdateONResponse>
    {
        public readonly ApplicationDbContext _applicationDbContext;
        public readonly MyAuthService _authService;
        public ProizvodStatusUpdateONEndpoint(ApplicationDbContext applicationDbContext, MyAuthService authService)
        {
            _applicationDbContext = applicationDbContext;
            _authService = authService;
        }
        [HttpPost]
        public override async Task<ProizvodStatusUpdateONResponse> Obradi([FromQuery]ProizvodStatusUpdateONRequest request, CancellationToken cancellationToken)
        {
            if (!(_authService.isAdmin() && _authService.isLogiran()))
                throw new Exception("Korisnik nema permisiju admina ili nije logiran");

            var proizvod = _applicationDbContext.Proizvod.Where(x=>request.ProizvodID == x.ProizvodID).FirstOrDefault();
            if(proizvod == null){
                throw new Exception("Proizvod nije pronađen za id: " +  request.ProizvodID);
            }
            if(proizvod.isIzdvojen == true){
                throw new Exception("Proizvod je već izdvojen");
            }
            proizvod.isIzdvojen = true;
            await _applicationDbContext.SaveChangesAsync();
            return new ProizvodStatusUpdateONResponse
            {
                ProizvodID = request.ProizvodID
            };
        }
    }
}
