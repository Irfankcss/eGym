using Microsoft.AspNetCore.Mvc;
using eGym.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace eGym.Data.Controllers.ZalbaController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZalbaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ZalbaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zalba>>> GetAllZalbe()
        {
            return await _context.Zalba.Include(z => z.korisnik).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Zalba>> GetZalbaById(int id)
        {
            var zalba = await _context.Zalba.Include(z => z.korisnik)
                                            .FirstOrDefaultAsync(z => z.ID == id);
            if (zalba == null)
            {
                return NotFound();
            }

            return zalba;
        }

        [HttpPost]
        public async Task<ActionResult<Zalba>> CreateZalba([FromForm] int KorisnikID, [FromForm] string Tekst, [FromForm] IFormFile Slika)
        {
            var korisnik = await _context.Korisnik
              .FirstOrDefaultAsync(k => k.ID == KorisnikID);

            if (korisnik == null)
            {
                return NotFound($"Korisnik with ID {KorisnikID} not found.");
            }

            var zalba = new Zalba
            {
                KorisnikID = KorisnikID,
                korisnik = korisnik,
                Tekst = Tekst
            };

            if (Slika != null && Slika.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await Slika.CopyToAsync(memoryStream);
                    zalba.Slika = memoryStream.ToArray();
                }
            }

            _context.Zalba.Add(zalba);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetZalbaById), new { id = zalba.ID }, zalba);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZalba(int id)
        {
            var zalba = await _context.Zalba.FindAsync(id);
            if (zalba == null)
            {
                return NotFound();
            }

            _context.Zalba.Remove(zalba);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
