using eGym.Data.Controllers.Obavijesti.Update;
using eGym.Helper;
using Microsoft.AspNetCore.Mvc;

namespace eGym.Data.Controllers.ProizvodStatus.UpdateON
{
    [Tags("ProizvodStatus")]
    public class ProizvodStatusUpdateONEndpoint : MyBaseEndpoint<ProizvodStatusUpdateONRequest, ProizvodStatusUpdateONResponse>
    {
        public readonly ApplicationDbContext _applicationDbContext;
        public ProizvodStatusUpdateONEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpPost]
        public override async Task<ProizvodStatusUpdateONResponse> Obradi([FromQuery]ProizvodStatusUpdateONRequest request, CancellationToken cancellationToken)
        {
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
