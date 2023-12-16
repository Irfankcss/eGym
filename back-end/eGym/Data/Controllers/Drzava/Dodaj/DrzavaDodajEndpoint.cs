using eGym.Helper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace eGym.Data.Controllers.Drzava.Dodaj
{
    [Tags("Drzava")]
    public class DrzavaDodajEndpoint : MyBaseEndpoint<DrzavaDodajRequest, DrzavaDodajResponse>
    {
        public readonly ApplicationDbContext _applicationDbContext;
        public DrzavaDodajEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpPost]
        public override async Task<DrzavaDodajResponse> Obradi([FromBody] DrzavaDodajRequest request, CancellationToken cancellationToken)
        {
            var noviObj = new Data.Models.Drzava{
                Naziv = request.Naziv,
                Skracenica = request.Skracenica
            };
            _applicationDbContext.Drzava.Add(noviObj);//

            await _applicationDbContext.SaveChangesAsync();
            return new DrzavaDodajResponse
            {
                DrzavaID = noviObj.ID
            };
        }
    }
}
