using eGym.Helper;
using Microsoft.AspNetCore.Mvc;

namespace eGym.Data.Endpoints.BrendEndpoints.Dodaj
{
    [Route("Brend")]
    [Tags("Brend")]
    public class BrendDodajEndpoint : MyBaseEndpoint<BrendDodajRequest,BrendDodajResponse>
    {
        private readonly ApplicationDbContext _context;
        public BrendDodajEndpoint(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("Dodaj")]
        public override async Task<BrendDodajResponse> Obradi([FromQuery] BrendDodajRequest request, CancellationToken cancellationToken)
        {
            if (request.BrendNaziv == null)
            {
                throw new Exception("Brend mora imati ime");
            }
            var noviobj = new Models.Brend { NazivBrenda = request.BrendNaziv };
            _context.Brend.Add(noviobj);
            await _context.SaveChangesAsync(cancellationToken);  

            return new BrendDodajResponse { BrendId = noviobj.BrendId }; 
        }
    }
}
