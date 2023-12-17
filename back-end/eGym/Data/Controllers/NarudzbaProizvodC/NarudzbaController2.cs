using eGym.Data.Models;
using eGym.Data.ViewModels.NarudzbaVMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eGym.Data.Controllers.NarudzbaProizvodC
{
    [Route("Narudzba2")]
    [ApiController]
    public class NarudzbaController2 : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public NarudzbaController2(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("NarudzbaGetAll")]
        public async Task<ActionResult<IEnumerable<NarudzbaVM>>> GetNarudzba()
        {

            var narudzbe = await _context.Narudzba
            .Include(n => n.Proizvodi)
            .ThenInclude(np => np.Proizvod)
            .ThenInclude(p => p.Brend)
            .Include(p => p.Proizvodi).ThenInclude(np => np.Proizvod).ThenInclude(p => p.Kategorija)
             .Select(x => new NarudzbaVM
             {
                 Id = x.Id,
                 DatumKreiranja = x.DatumKreiranja,
                 isOdobrena = x.isOdobrena,
                 Vrijednost = x.Vrijednost,
                 Popust = x.Popust,
                 KorisnikID = x.KorisnikID,
                 NacinPlacanja = x.NacinPlacanja,
                 Proizvodi = x.Proizvodi.Select(np => np.Proizvod).ToList()
             }).ToListAsync();
              return narudzbe;

        }
        [HttpPost("DodajNarudzbu")]
        public async Task<ActionResult<Narudzba>> PostNarudzba(DodajNarudzbuVM dodajNarudzbuVM)
        {
            var narudzba = new Narudzba
            {
                DatumKreiranja = dodajNarudzbuVM.DatumNarudzbe,
                isOdobrena = false,
                Vrijednost = dodajNarudzbuVM.vrijednost,
                Popust = dodajNarudzbuVM.Popust,
                KorisnikID = dodajNarudzbuVM.KorisnikID,
                NacinPlacanja = dodajNarudzbuVM.NacinPlacanja,
                Proizvodi = new List<NarudzbaProizvod>(),
                isPoslana = false
            };

            foreach (var proizvodId in dodajNarudzbuVM.ProizvodIDs)
            {
                var proizvod = await _context.Proizvod.FindAsync(proizvodId);

                if (proizvod == null)
                {
                    ModelState.AddModelError("ProizvodIDs", $"Proizvod with ID {proizvodId} not found.");
                    return BadRequest(ModelState);
                }

                var narudzbaProizvod = new NarudzbaProizvod
                {
                    ProizvodId = proizvodId,
                    Proizvod = proizvod,
                    Kolicina = 1 
                };

                narudzba.Proizvodi.Add(narudzbaProizvod);
            }

            _context.Narudzba.Add(narudzba);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetNarudzba), new { id = narudzba.Id }, narudzba);
        }
        [HttpGet("NarudzbaGetBy{id}")]
        public async Task<ActionResult<NarudzbaVM>> GetNarudzba(int id)
        {
            var narudzba = await _context.Narudzba
                .Include(n => n.Proizvodi)
                    .ThenInclude(np => np.Proizvod)
                        .ThenInclude(p => p.Brend)
                    .Include(p => p.Proizvodi).ThenInclude(np=> np.Proizvod).ThenInclude(p=>p.Kategorija)
                .FirstOrDefaultAsync(n => n.Id == id);

            if (narudzba == null)
            {
                return NotFound();
            }

            var narudzbaVM = new NarudzbaVM
            {
                Id = narudzba.Id,
                DatumKreiranja = narudzba.DatumKreiranja,
                isOdobrena = narudzba.isOdobrena,
                Vrijednost = narudzba.Vrijednost,
                Popust = narudzba.Popust,
                KorisnikID = narudzba.KorisnikID,
                NacinPlacanja = narudzba.NacinPlacanja,
                Proizvodi = narudzba.Proizvodi.Select(np => np.Proizvod).ToList()
            };

            return narudzbaVM;
        }
    }
}
