using eGym.Helper;
using Microsoft.AspNetCore.Mvc;

namespace eGym.Data.Controllers.Obavijesti.Update
{
    [Tags("Obavijest")]
    public class ObavijestiUpdateEndpoint : MyBaseEndpoint<ObavijestiUpdateRequest, ObavijestiUpdateResponse>
    {
        public readonly ApplicationDbContext _applicationDbContext;
        public ObavijestiUpdateEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpPost]
        public override async Task<ObavijestiUpdateResponse> Obradi([FromBody]ObavijestiUpdateRequest request, CancellationToken cancellationToken)
        {
            var obavijest = _applicationDbContext.Obavjesti.Where(x=>request.ID ==  x.ID).FirstOrDefault();
            if(obavijest == null)
            {
                throw new Exception("Ne postoji obavijest za id: " + request.ID);
            }
            obavijest.Text = request.Sadrzaj;
            obavijest.Naslov = request.Naslov;
            await _applicationDbContext.SaveChangesAsync();
            return new ObavijestiUpdateResponse
            {
            };
        }
    }
}
