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
                .Include(n => n.Proizvodi)
                    .ThenInclude(np => np.Proizvod)
                        .ThenInclude(p => p.Kategorija)
                .Select(x => new NarudzbaVM
                {
                    Id = x.Id,
                    DatumKreiranja = x.DatumKreiranja,
                    isOdobrena = x.isOdobrena,
                    Vrijednost = x.Vrijednost,
                    Popust = x.Popust,
                    KorisnikID = x.KorisnikID,
                    NacinPlacanja = x.NacinPlacanja,
                    NacinDostave = x.NacinDostave,
                    ImePrimaoca = x.ImePrimaoca,
                    PrezimePrimaoca = x.PrezimePrimaoca,
                    Adresa = x.Adresa,
                    Grad = x.Grad,
                    Telefon = x.Telefon,
                    Email = x.Email,
                    Proizvodi = x.Proizvodi.Select(np => new NarudzbaProizvodVM
                    {
                        Proizvod = np.Proizvod,
                        Kolicina = np.Kolicina
                    }).ToList()
                }).ToListAsync();

            return Ok(narudzbe);
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


        [HttpPost("CreateNarudzbaFromKorpa/{korpaId}")]
        public async Task<IActionResult> CreateNarudzbaFromKorpa(int korpaId, [FromBody] CreateNarudzbaDto dto)
        {
            var korpa = await _context.Korpa
                .Include(k => k.Proizvodi)
                    .ThenInclude(kp => kp.Proizvod)
                .Include(k => k.korisnik)
                .FirstOrDefaultAsync(k => k.KorpaID == korpaId);

            if (korpa == null)
            {
                return NotFound("Korpa not found");
            }

            double ukupnaVrijednost = korpa.Proizvodi.Sum(kp =>
            {
                var cijena = kp.Proizvod.Cijena;
                var popust = kp.Proizvod.popust;
                var cijenaNakonPopusta = cijena - (cijena * (popust / 100));
                return cijenaNakonPopusta * kp.Kolicina ?? 0;
            });

            var narudzba = new Narudzba
            {
                DatumKreiranja = DateTime.Now,
                isOdobrena = false,
                Vrijednost = ukupnaVrijednost,
                KorisnikID = korpa.KorisnikID,
                korisnik = korpa.korisnik,
                NacinPlacanja = dto.NacinPlacanja,
                Popust = dto.Popust,
                NacinDostave= dto.NacinDostave,
                GradID = dto.GradID,
                ImePrimaoca = dto.ImePrimaoca,
                PrezimePrimaoca= dto.PrezimePrimaoca,
                Adresa= dto.Adresa,
                Telefon= dto.Telefon,
                Email= dto.Email,
                Proizvodi = new List<NarudzbaProizvod>()
            };
            if (narudzba.NacinDostave == "Regular")
                narudzba.Vrijednost += 7;

            foreach (var korpaProizvod in korpa.Proizvodi)
            {
                var narudzbaProizvod = new NarudzbaProizvod
                {
                    Narudzba = narudzba,
                    Proizvod = korpaProizvod.Proizvod,
                    Kolicina = korpaProizvod.Kolicina
                };
                narudzba.Proizvodi.Add(narudzbaProizvod);
            }

            _context.Narudzba.Add(narudzba);

            _context.KorpaProizvod.RemoveRange(korpa.Proizvodi);

            await _context.SaveChangesAsync();

            return Ok(narudzba);
        }




        [HttpGet("NarudzbaGetBy{id}")]
        public async Task<ActionResult<NarudzbaVM>> GetNarudzba(int id)
        {
            var narudzba = await _context.Narudzba
                .Include(n => n.Proizvodi)
                    .ThenInclude(np => np.Proizvod)
                        .ThenInclude(p => p.Slike)
                .Include(n => n.Proizvodi)
                    .ThenInclude(np => np.Proizvod)
                        .ThenInclude(p => p.Brend)
                .Include(n => n.Proizvodi)
                    .ThenInclude(np => np.Proizvod)
                        .ThenInclude(p => p.Kategorija)
                .Include(n => n.Grad)
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
                NacinDostave = narudzba.NacinDostave,
                ImePrimaoca = narudzba.ImePrimaoca,
                PrezimePrimaoca = narudzba.PrezimePrimaoca,
                Adresa = narudzba.Adresa,
                Grad = narudzba.Grad,
                Telefon = narudzba.Telefon,
                Email = narudzba.Email,
                Proizvodi = narudzba.Proizvodi.Select(np => new NarudzbaProizvodVM
                {
                    Proizvod = np.Proizvod,
                    Kolicina = np.Kolicina
                }).ToList()
            };

            return narudzbaVM;
        }
    }
}
