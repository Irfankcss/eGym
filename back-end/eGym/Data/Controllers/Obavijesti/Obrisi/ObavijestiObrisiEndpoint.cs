using eGym.Helper;
using Microsoft.AspNetCore.Mvc;

namespace eGym.Data.Controllers.Obavijesti.Obrisi
{
    [Tags("Obavijest")]
    public class ObavijestiObrisiEndpoint : MyBaseEndpoint<ObavijestiObrisiRequest, ObavijestiObrisiResponse>
    {
        public readonly ApplicationDbContext _applicationDbContext;
        public ObavijestiObrisiEndpoint (ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpDelete]
        public override async Task<ObavijestiObrisiResponse> Obradi([FromQuery] ObavijestiObrisiRequest request, CancellationToken cancellationToken)
        {
            var obavijesti = _applicationDbContext.Obavjesti.FirstOrDefault(x => x.ID == request.ObavijestID);
            if (obavijesti == null)
            {
                throw new Exception("Nije pronadjena obavijest za id: " + request.ObavijestID);
            }
            _applicationDbContext.Remove(obavijesti);
            await _applicationDbContext.SaveChangesAsync();

            return new ObavijestiObrisiResponse
            {

            };
        }
    }
}
