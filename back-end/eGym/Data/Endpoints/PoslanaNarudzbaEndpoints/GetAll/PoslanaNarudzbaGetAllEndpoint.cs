using eGym.Data.Models;
using eGym.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eGym.Data.Endpoints.PoslanaNarudzbaEndpoints.GetAll
{
    [Route("PoslanaNarudzba")]
    [Tags("Poslana Narudzba")]
    public class PoslanaNarudzbaGetAllEndpoint : MyBaseEndpoint<int?, List<PoslanaNarudzbaGetAllResponse>>
    {
        private readonly ApplicationDbContext _context;
        public PoslanaNarudzbaGetAllEndpoint(ApplicationDbContext context)
        {
            _context = context;
        }

        //[HttpGet("GetAll")]
        //public override async Task<PoslanaNarudzba> Obradi(int request, CancellationToken cancellationToken)
        //{
        //    var pn = await _context.PoslanaNarudzba.Include(p=>p.korisnik).ThenInclude(k=>k.OpstinaRodjenja).ThenInclude(g=>g.Drzava).Include(p=>p.Radnik).ThenInclude(r=>r.grad).ThenInclude(gr=>gr.Drzava).FirstOrDefaultAsync(x => x.Id == request);
        //    if (pn == null) { throw new Exception("Odabrana PoslanaNarudzba ne postoji"); }
        //    return pn;
        //}



        [HttpGet("PoslanaNarudzba Get by NarudzbaID")]
        public override async Task<List<PoslanaNarudzbaGetAllResponse>> Obradi(int? NarudzbaID, CancellationToken cancellationToken)
        {
            var pn = await _context.PoslanaNarudzba.Include(p=>p.Radnik).ThenInclude(r=>r.grad).ThenInclude(g=>g.Drzava).Where(x => NarudzbaID == null || x.NarudzbaID == NarudzbaID).Select(x=> new PoslanaNarudzbaGetAllResponse
            {
                PoslanaNarudzbaID = x.PoslanaNarudzbaID,
                DatumIsporuke =x.DatumIsporuke,
                DatumSlanja =x.DatumSlanja,
                DatumPreuzimanja =x.DatumPreuzimanja,
                isIsporucena=x.isIsporucena,
                isPreuzeta=x.isPreuzeta,
                Radnik= x.Radnik
                ,NarudzbaID=x.NarudzbaID

            }).ToListAsync(cancellationToken: cancellationToken);

            return  pn;
        }
    }
}
