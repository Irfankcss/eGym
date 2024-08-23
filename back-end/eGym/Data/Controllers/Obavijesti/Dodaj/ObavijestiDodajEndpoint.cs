using eGym.Data.Helpers.Services;
using eGym.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace eGym.Data.Controllers.Obavijesti.Dodaj
{
    [Tags("Obavijest")]
    public class ObavijestiDodajEndpoint : MyBaseEndpoint<ObavijestiDodajRequest, ObavijestiDodajResponse>
    {
        public readonly ApplicationDbContext _applicationDbContext;
        private readonly MyAuthService _authService;
        public ObavijestiDodajEndpoint (ApplicationDbContext applicationDbContext,MyAuthService authService) { 
            _applicationDbContext = applicationDbContext;
            _authService = authService;
        }
        [HttpPost]
        public override async Task<ObavijestiDodajResponse> Obradi([FromBody] ObavijestiDodajRequest request, CancellationToken cancellationToken)
        {
            if (!_authService.isAdmin())
                throw new Exception("Korisnik nema permisiju admina");

            var noviObj = new Data.Models.Obavjesti
            {
                DatumObjave = request.DatumObjave,
                Naslov = request.Naslov,
                Text = request.Text,
                Slika = request.Slika,
                AdminID = request.AdminID,
                isHidden = false
            };
            var BrojObavijesti = _applicationDbContext.Obavjesti.Count();
            if(BrojObavijesti > 2)
            {
                var obavijest = _applicationDbContext.Obavjesti.Where(x => x.isHidden == false).FirstOrDefault();
                if(obavijest != null){
                    obavijest.isHidden = true;
                }
            }
            _applicationDbContext.Add(noviObj);
            await _applicationDbContext.SaveChangesAsync();


            return new ObavijestiDodajResponse
            {
                ObavijestiID = noviObj.ID
            };
        }
    }
}
