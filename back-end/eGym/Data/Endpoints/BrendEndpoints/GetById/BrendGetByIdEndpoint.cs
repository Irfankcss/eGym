using eGym.Data.Models;
using eGym.Helper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eGym.Data.Endpoints.BrendEndpoints.GetById
{
    [Microsoft.AspNetCore.Mvc.Route("Brend")]
    [Tags("Brend")]
    public class BrendGetByIdEndpoint : MyBaseEndpoint<int,BrendGetByIdResponse>
    {
        private readonly ApplicationDbContext _context;

        public BrendGetByIdEndpoint (ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("Brend po Id")]
        public override async Task<BrendGetByIdResponse> Obradi(int request, CancellationToken cancellationToken)
        {
            var noviobj = await _context.Brend
            .OrderByDescending(x => x.BrendId)
            .Select(x => new BrendGetByIdResponse
            {
                Id=x.BrendId,
                BrendNaziv=x.NazivBrenda
            })
            .SingleAsync(x => x.Id == request, cancellationToken: cancellationToken);
            return noviobj;
        }
    }
}
