using eGym.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eGym.Data.Endpoints.BrendEndpoints.Izbriši
{
    [Microsoft.AspNetCore.Mvc.Route("Brend")]
    [Tags("Brend")]
    public class BrendIzbrisiEndpoint : MyBaseEndpoint<int, int>
    {
        private readonly ApplicationDbContext _context;
        public BrendIzbrisiEndpoint(ApplicationDbContext context) => _context = context;

        [HttpDelete("BrenIzbrisi")]
        public override async Task<int> Obradi(int request, CancellationToken cancellationToken)
        {
            var brend = await _context.Brend.FirstOrDefaultAsync(x => x.BrendId == request);
            if (brend == null)
                throw new Exception("ne postoji brend sa tim id-jem");
            _context.Brend.Remove(brend);
            await _context.SaveChangesAsync(cancellationToken);
            return request;
        }
    }
}
