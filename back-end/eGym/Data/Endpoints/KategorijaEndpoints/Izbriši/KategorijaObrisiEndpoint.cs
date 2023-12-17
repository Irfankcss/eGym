using eGym.Helper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eGym.Data.Endpoints.KategorijaEndpoints.Izbriši
{
    [Microsoft.AspNetCore.Mvc.Route("Kategorija")]
    [Tags("Kategorija")]
    public class KategorijaObrisiEndpoint : MyBaseEndpoint<int,int>
    {
        private readonly ApplicationDbContext _context;
        public KategorijaObrisiEndpoint(ApplicationDbContext context) => _context = context;

        [HttpDelete("KategorijaObrisi")]
        public override async Task<int> Obradi(int request, CancellationToken cancellationToken)
        {
            var kategorija = await _context.Kategorija.FirstOrDefaultAsync(x=>x.Id==request);
            if (kategorija == null)
                throw new Exception("ne postoji kategorija sa tim id-jem");
            _context.Kategorija.Remove(kategorija);
            await _context.SaveChangesAsync(cancellationToken);
            return request;
        }
    }
}
