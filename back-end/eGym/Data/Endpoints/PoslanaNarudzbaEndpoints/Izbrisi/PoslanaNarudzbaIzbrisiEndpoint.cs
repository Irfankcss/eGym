using eGym.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eGym.Data.Endpoints.PoslanaNarudzbaEndpoints.Izbrisi
{
    [Route("PoslanaNarudzba")]
    [Tags("Poslana Narudzba")]
    public class PoslanaNarudzbaIzbrisiEndpoint : MyBaseEndpoint<int,string>
    {
        private readonly ApplicationDbContext _context;
        public PoslanaNarudzbaIzbrisiEndpoint(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpDelete("PoslanaNarudzba izbrisi")]
        public override async Task<string> Obradi(int request, CancellationToken cancellationToken)
        {
            var poslananarudzba= await _context.PoslanaNarudzba.FirstAsync(x=>x.PoslanaNarudzbaID==request);
            if (poslananarudzba == null)
            {
                return "PoslanaNarudzba ne postoji";
            }
            _context.PoslanaNarudzba.Remove(poslananarudzba);
            await _context.SaveChangesAsync();
            return "PoslanaNarudzba izbrisana";
        }
    }
}
