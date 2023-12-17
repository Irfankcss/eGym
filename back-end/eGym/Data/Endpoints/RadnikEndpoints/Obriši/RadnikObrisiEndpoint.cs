using eGym.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eGym.Data.Endpoints.RadnikEndpoints.Obriši
{
    [Route("Radnik")]
    [Tags("Radnik")]
    public class RadnikObrisiEndpoint : MyBaseEndpoint<int,int>
    {
        private readonly ApplicationDbContext _context;
        public RadnikObrisiEndpoint(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpDelete("Obrisi")]
        public override async Task<int> Obradi([FromQuery]int request, CancellationToken cancellationToken)
        {
            var radnik = await _context.Radnik.FirstOrDefaultAsync(x=> x.ID == request);
            if (radnik == null) throw new Exception("Nema radnika sa tim id-jem");
            _context.Radnik.Remove(radnik);
            await _context.SaveChangesAsync(cancellationToken);
            return request;
        }
    }
}
