using eGym.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eGym.Data.Endpoints.PoslanaNarudzbaEndpoints.GetAll
{
    [Route("PoslanaNarudzba")]
    [Tags("Poslana Narudzba")]
    public class PoslanaNarudzbaGetByRadnikIDEndpoint : MyBaseEndpoint<int, List<PoslanaNarudzbaGetAllResponse>>
    {
        private readonly ApplicationDbContext _context;
        public PoslanaNarudzbaGetByRadnikIDEndpoint(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("PoslanaNarudzba Get by RadnikID")]
        public override async Task<List<PoslanaNarudzbaGetAllResponse>> Obradi(int RadnikID, CancellationToken cancellationToken)
        {
            var pn = await _context.PoslanaNarudzba.Include(p => p.Radnik).ThenInclude(r => r.grad).ThenInclude(g => g.Drzava).Where(x => x.Radnik.ID == RadnikID).Select(x => new PoslanaNarudzbaGetAllResponse
            {
                PoslanaNarudzbaID = x.PoslanaNarudzbaID,
                DatumIsporuke = x.DatumIsporuke,
                DatumSlanja = x.DatumSlanja,
                DatumPreuzimanja = x.DatumPreuzimanja,
                isIsporucena = x.isIsporucena,
                isPreuzeta = x.isPreuzeta,
                Radnik = x.Radnik
                ,
                NarudzbaID = x.NarudzbaID

            }).ToListAsync(cancellationToken: cancellationToken);

            return pn;
        }

    }
}
