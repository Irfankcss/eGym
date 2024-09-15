using eGym.Data.Helpers.Services;
using eGym.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace eGym.Data.Endpoints.Obavijesti.Obrisi
{
    [Tags("Obavijest")]
    public class ObavijestiObrisiEndpoint : MyBaseEndpoint<ObavijestiObrisiRequest, ObavijestiObrisiResponse>
    {
        public readonly ApplicationDbContext _applicationDbContext;
        public readonly MyAuthService _authService;
        public ObavijestiObrisiEndpoint(ApplicationDbContext applicationDbContext, MyAuthService authService)
        {
            _applicationDbContext = applicationDbContext;
            _authService = authService;
        }
        [HttpDelete]
        public override async Task<ObavijestiObrisiResponse> Obradi([FromQuery] ObavijestiObrisiRequest request, CancellationToken cancellationToken)
        {
            if (!(_authService.isAdmin() && _authService.isLogiran()))
                throw new Exception("Korisnik nema permisiju admina ili nije logiran");

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
