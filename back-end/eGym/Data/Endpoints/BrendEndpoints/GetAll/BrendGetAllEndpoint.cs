using eGym.Data.Endpoints.KategorijaEndpoints.GetAll;
using eGym.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace eGym.Data.Endpoints.BrendEndpoints.GetAll
{
    [Route("Brend")]
    public class BrendGetAllEndpoint : MyBaseEndpoint<BrendGetAllRequest,BrendGetAllResponse>
    {
        private readonly ApplicationDbContext _context;
        public BrendGetAllEndpoint(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("GetAll")]
        public override async Task<BrendGetAllResponse> Obradi([FromQuery]BrendGetAllRequest request, CancellationToken cancellationToken)
        {
            var brendovi =  _context.Brend
            .Select(x => new BrendGetAllResponseBrend
             {
                 BrendID=x.BrendId,
                 Naziv=x.NazivBrenda
             }).ToList();

            return new BrendGetAllResponse
            {
                Brendovi=brendovi
            };
        }
    }
}
