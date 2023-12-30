using eGym.Data.Models;
using eGym.Data.ViewModels.ProizvodVMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Runtime.Intrinsics.X86;

namespace eGym.Data.Controllers.NarudzbaProizvodC
{
    [ApiController]
    [Route("api/products")]
    public class ProizvodController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ProizvodController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetProizvodi")]
        public async Task<IActionResult> GetProizvodByNaziv(CancellationToken cancellationToken)
        {
            var proizvod = await _context.Proizvod
                .Select(p => new ProizvodGetVM
                {
                    ProizvodID=p.ProizvodID,
                    Naziv = p.Naziv,
                    isIzdvojen = p.isIzdvojen,
                    Boja = p.Boja,
                    Slike = p.Slike,
                    Velicina = p.Velicina,
                    Brend = p.Brend,
                    Cijena = p.Cijena,
                    DatumObjave = p.DatumObjave,
                    Kategorija = p.Kategorija,
                    KolicinaNaSkladistu = p.KolicinaNaSkladistu,
                    Opis = p.Opis,
                    popust = p.popust
                }).ToListAsync(); ;

            if (proizvod == null)
            {
                return NotFound("Nema proizvoda u bazi");
            }

            return Ok(proizvod);
        }

        [HttpGet("GetProizvodByID")]
        public async Task<ActionResult<ProizvodVM>> GetProizvodByID(int proizvodId) {

            var p = await _context.Proizvod.Include(p=>p.Kategorija).Include(p=>p.Brend).Include(p=>p.Slike).FirstOrDefaultAsync(p => p.ProizvodID == proizvodId);
            
            var proizvod = new ProizvodVM
            {
                Naziv = p.Naziv,
                Cijena = p.Cijena,
                DatumObjave = p.DatumObjave,
                Slike = p.Slike,
                Velicina = p.Velicina,
                Kategorija = p.Kategorija,
                Opis = p.Opis,
                Brend = p.Brend,
                Boja = p.Boja,
                isIzdvojen = p.isIzdvojen,
                KolicinaNaSkladistu = p.KolicinaNaSkladistu,
                popust = p.popust,
            };
            if (p.Izbrisan)
            {
                proizvod = new ProizvodVM
                {
                    Naziv = "Izbrisan Proizvod",
                    Cijena = p.Cijena,
                    DatumObjave = p.DatumObjave,
                    Slike = p.Slike,
                    Velicina = p.Velicina,
                    Kategorija = p.Kategorija,
                    Opis = "Izbrisan Proizvod",
                    Brend = p.Brend,
                    Boja = p.Boja,
                    isIzdvojen = p.isIzdvojen,
                    KolicinaNaSkladistu = 0,
                    popust = 0,
                };
            }

            if (proizvod == null)
            {
                throw new Exception("Nepostojeci proizvod");
            }
            return Ok(proizvod);
        }

        [HttpGet("GetProizvodByNaziv/{nazivProizvoda}")]
        public async Task<IActionResult> GetProizvodByNaziv(string nazivProizvoda)
        {
            var proizvod = await _context.Proizvod
                .Where(p => p.Naziv.ToLower().StartsWith(nazivProizvoda.ToLower())).Select(p => new ProizvodGetVM
                {
                    ProizvodID=p.ProizvodID,
                    Naziv = p.Naziv,
                    isIzdvojen = p.isIzdvojen,
                    Boja = p.Boja,
                    Slike = p.Slike,
                    Velicina = p.Velicina,
                    Brend = p.Brend,
                    Cijena = p.Cijena,
                    DatumObjave = p.DatumObjave,
                    Kategorija = p.Kategorija,
                    KolicinaNaSkladistu = p.KolicinaNaSkladistu,
                    Opis = p.Opis,
                    popust = p.popust
                }).ToListAsync(); ;

            if (proizvod == null)
            {
                return NotFound("Proizvod nije pronadjen");
            }

            return Ok(proizvod);
        }
        [HttpPost]
        public async Task<IActionResult> PostProizvod(ProizvodVM proizvodvm)
        {
            var proizvod = new Proizvod
            {
                Naziv = proizvodvm.Naziv,
                Kategorija = proizvodvm.Kategorija,
                KategorijaID = proizvodvm.Kategorija.Id,
                Boja = proizvodvm.Boja,
                Cijena = proizvodvm.Cijena,
                Brend = proizvodvm.Brend,
                BrendID = proizvodvm.Brend.BrendId,
                DatumObjave = proizvodvm.DatumObjave,
                isIzdvojen = false,
                Izbrisan = false,
                KolicinaNaSkladistu=proizvodvm.KolicinaNaSkladistu,
                Opis=proizvodvm.Opis,
                popust=proizvodvm.popust,
                Velicina=proizvodvm.Velicina,
                Slike=proizvodvm.Slike,
            };
            var kategorija = await _context.Kategorija.FirstOrDefaultAsync(k => k.NazivKategorije == proizvodvm.Kategorija.NazivKategorije);
            var brend = await _context.Brend.FirstOrDefaultAsync(b => b.NazivBrenda == proizvodvm.Brend.NazivBrenda);
            if (kategorija != null)
            {
                proizvod.Kategorija = kategorija;
                proizvod.KategorijaID = kategorija.Id;
            }
            if(brend != null)
            {
                proizvod.Brend = brend;
                proizvod.BrendID=brend.BrendId;
            }
            _context.Proizvod.Add(proizvod);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProizvod), new { id = proizvodvm.Naziv }, proizvodvm);
        }
        [HttpGet("GetProizvod/{id} NE KORISTI SE")]
        public async Task<IActionResult> GetProizvod(int id)
        {
            var proizvod = await _context.Proizvod.FindAsync(id);

            if (proizvod == null)
            {
                return NotFound();
            }

            return Ok(proizvod);
        }
        [HttpDelete("DeleteProizvod/{proizvodID}")]
        public async Task<IActionResult> DeleteProizvod(int proizvodID)
        {
            var proizvod = await _context.Proizvod.FindAsync(proizvodID);

            if (proizvod == null)
            {
                return NotFound("Proizvod nije pronadjen");
            }

            _context.Proizvod.Remove(proizvod);
            await _context.SaveChangesAsync();

            return Ok("Proizvod obrisan");
        }

        [HttpGet("GetProizvodiByKategorijaID/{kategorijaID}")]
        public async Task<IActionResult> GetProizvodiByKategorijaID2(int kategorijaID)
        {
            var proizvodi = await _context.Proizvod
                .Where(p => p.KategorijaID == kategorijaID)
                .Select(p=> new ProizvodGetVM
                {
                    ProizvodID=p.ProizvodID,
                    Naziv=p.Naziv,
                    isIzdvojen=p.isIzdvojen,
                    Boja=p.Boja,
                    Slike=p.Slike,
                    Velicina=p.Velicina,
                    Brend=p.Brend,Cijena=p.Cijena,
                    DatumObjave=p.DatumObjave,Kategorija=p.Kategorija,
                    KolicinaNaSkladistu = p.KolicinaNaSkladistu,Opis = p.Opis,popust = p.popust
                }).ToListAsync();

            if (!proizvodi.Any())
            {
                return NotFound("Nema proizvoda u toj kategoriji");
            }

            return Ok(proizvodi);
        }

    }
}
