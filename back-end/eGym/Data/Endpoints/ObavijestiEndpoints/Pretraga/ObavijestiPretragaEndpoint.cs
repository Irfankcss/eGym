using eGym.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eGym.Data.Endpoints.Obavijesti.Pretraga
{
    [Tags("Obavijest")]
    public class ObavijestiPretragaEndpoint : MyBaseEndpoint<ObavijestiPretragaRequest, ObavijestiPretragaResponse>
    {
        public readonly ApplicationDbContext _applicationDbContext;
        public ObavijestiPretragaEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        public override async Task<ObavijestiPretragaResponse> Obradi([FromQuery] ObavijestiPretragaRequest request, CancellationToken cancellationToken)
        {
            var obavijesti = await _applicationDbContext.Obavjesti.Where(x => x.isHidden == false)
                .Select(x => new ObavijestiPretragaResponseObavijest
                {
                    ID = x.ID,
                    DatumObjave = x.DatumObjave,
                    Naslov = x.Naslov,
                    Text = x.Text,
                    Slika = x.Slika,
                    Admin = x.Admin.KorisnickoIme
                }).ToListAsync();
            return new ObavijestiPretragaResponse
            {
                Obavijesti = obavijesti
            };
        }
    }
}
