using eGym.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static eGym.Data.Controllers.Grad.Pretraga.GradPretragaResponse;

namespace eGym.Data.Controllers.Grad.Pretraga
{
    [Tags("Grad")]
    public class GradPretragaEndpoint : MyBaseEndpoint<GradPretragaRequest, GradPretragaResponse>
    {
        public readonly ApplicationDbContext _applicationDbContext;
        public GradPretragaEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        public override async Task<GradPretragaResponse> Obradi([FromQuery] GradPretragaRequest request, CancellationToken cancellationToken)
        {
            var gradovi = await _applicationDbContext.Grad
                .Select(x => new GradPretragaResponseGrad
                {
                    ID = x.ID,
                    Naziv=x.Naziv,
                    PostanskiBroj = x.PostanskiBroj,
                    Drzava = x.Drzava.Naziv
                }).ToListAsync();

            return new GradPretragaResponse
            {
                Gradovi = gradovi
            };
        }
    }
}
