using eGym.Data.Models;
using eGym.Helper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eGym.Data.Endpoints.PoslanaNarudzbaEndpoints.Dodaj
{
    [Microsoft.AspNetCore.Mvc.Route("PoslanaNarudzba")]
    [Tags("Poslana Narudzba")]
    public class PoslanaNarudzbaDodajEndpoint : MyBaseEndpoint<PoslanaNarudzbaDodajRequest, int>
    {
        private readonly ApplicationDbContext _context;
        public PoslanaNarudzbaDodajEndpoint(ApplicationDbContext context)
        {
            _context = context;
        }

       
        [HttpPost("Posalji narudzbu")]
        public override async Task<int> Obradi(PoslanaNarudzbaDodajRequest request, CancellationToken cancellationToken)
        {
            var _radnik = await _context.Radnik.FirstOrDefaultAsync(r => r.ID == request.RadnikID);
            var narudzba = await _context.Narudzba.AsNoTracking().Include(k=>k.korisnik).FirstAsync(n => n.Id == request.NarudzbaID);


            if (_radnik == null || narudzba == null)
            {
                throw new Exception("radnik ili narudzba ne postoje");
            }
            
            if (narudzba.isPoslana) { throw new Exception("Narudzba je vec poslana"); }

            var noviobj = new PoslanaNarudzba
            {
                NarudzbaID = request.NarudzbaID,
                DatumSlanja = DateTime.Now,
                Radnik=_radnik,
                isIsporucena = false,
                isPreuzeta = false,
            };
            narudzba.isPoslana = true;
            _context.Narudzba.Update(narudzba);
            await _context.SaveChangesAsync();

            
            _context.PoslanaNarudzba.Add(noviobj);
            await _context.SaveChangesAsync();


            return noviobj.PoslanaNarudzbaID;
        }
    }
}
