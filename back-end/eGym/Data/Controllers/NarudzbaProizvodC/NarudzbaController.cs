using eGym.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eGym.Data.Controllers.NarudzbaProizvodC
{
    [ApiController]
    [Route("api/orders")]
    public class NarudzbaController : ControllerBase
    { 
        private readonly ApplicationDbContext _context;
        
        public NarudzbaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public int DodajNarudzbu(DodajNarudzbuRequest dodajnarudzbu)
        {
            var order = new Narudzba
            {
                DatumKreiranja = dodajnarudzbu.DatumNarudzbe,
                NarudzbaProizvodi = dodajnarudzbu.ProizvodIDs.Select(proizvodID => new NarudzbaProizvod
                {
                    ProizvodId = proizvodID,

                }).ToList(),
                isOdobrena = false,
                Vrijednost = dodajnarudzbu.vrijednost,
                KorisnikID = dodajnarudzbu.KorisnikID,
                Popust = dodajnarudzbu.Popust,
                NacinPlacanja = dodajnarudzbu.NacinPlacanja
            };

            _context.Narudzba.Add(order);
            _context.SaveChanges();

            return order.Id;
        }
        // GET api/orders/{orderId}
        [HttpGet]
        public async Task<IActionResult> GetNarudzbe()
        {
            var narudzbe = await _context.Narudzba.ToListAsync();
            return Ok(narudzbe);
        }

        // GET: api/narudzbe/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNarudzba(int id)
        {
            var narudzba = await _context.Narudzba
                .Include(n => n.korisnik)
                .Include(n => n.NarudzbaProizvodi)
                .FirstOrDefaultAsync(n => n.Id == id);

            if (narudzba == null)
            {
                return NotFound("Narudzba not found");
            }

            return Ok(narudzba);
        }
    }
}
    

