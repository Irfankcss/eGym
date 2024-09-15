using eGym.Data.Helpers.Services;
using eGym.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace eGym.Data.Endpoints.Obavijesti.Update
{
    [Tags("Obavijest")]
    public class ObavijestiUpdateEndpoint : MyBaseEndpoint<ObavijestiUpdateRequest, ObavijestiUpdateResponse>
    {
        public readonly ApplicationDbContext _applicationDbContext;
        public readonly MyAuthService _authService;
        public ObavijestiUpdateEndpoint(ApplicationDbContext applicationDbContext, MyAuthService authService)
        {
            _applicationDbContext = applicationDbContext;
            _authService = authService;
        }
        [HttpPost]
        public override async Task<ObavijestiUpdateResponse> Obradi([FromBody] ObavijestiUpdateRequest request, CancellationToken cancellationToken)
        {
            if (!(_authService.isAdmin() && _authService.isLogiran()))
                throw new Exception("Korisnik nema permisiju admina ili nije logiran");

            var obavijest = _applicationDbContext.Obavjesti.Where(x => request.ID == x.ID).FirstOrDefault();
            if (obavijest == null)
            {
                throw new Exception("Ne postoji obavijest za id: " + request.ID);
            }
            obavijest.Text = request.Sadrzaj;
            obavijest.Naslov = request.Naslov;
            obavijest.Slika = request.Slika;
            await _applicationDbContext.SaveChangesAsync();
            return new ObavijestiUpdateResponse
            {
            };
        }
    }
}
