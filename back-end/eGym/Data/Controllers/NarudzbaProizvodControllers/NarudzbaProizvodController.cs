using eGym.Data.ViewModels.ProizvodVMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eGym.Data.Controllers.NarudzbaProizvodC
{
    [Route("api/orders")]
    public class NarudzbaProizvodController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public NarudzbaProizvodController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("Get Proizvodi u narudzbi")]
        public async Task<IActionResult> GetProizvodiForNarudzba(int narudzbaId)
        {
            try
            {
                var narudzbaProizvodi = await _context.NarudzbaProizvod
                    .Where(np => np.NarudzbaId == narudzbaId)
                    .Include(np => np.Proizvod).ThenInclude(p=>p.Brend)
                    .Include(np=>np.Proizvod).ThenInclude(p=>p.Kategorija)
                    .Include(np => np.Proizvod).ThenInclude(p => p.Slike)
                    .ToListAsync();

                if (narudzbaProizvodi == null || !narudzbaProizvodi.Any())
                {
                    return NotFound($"No Proizvodi found for Narudzba with ID {narudzbaId}");
                }

                var proizvodiDto = narudzbaProizvodi.Select(np => new ProizvodVM
                { 
                    Naziv = np.Proizvod.Naziv,
                    Opis = np.Proizvod.Opis,
                    Cijena = np.Proizvod.Cijena,
                    Boja=np.Proizvod.Boja,
                    Brend=np.Proizvod.Brend,
                    popust=np.Proizvod.popust,
                    Velicina=np.Proizvod.Velicina,
                    Kategorija=np.Proizvod.Kategorija,
                    KolicinaNaSkladistu=np.Proizvod.KolicinaNaSkladistu

                }).ToList();

                return Ok(proizvodiDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
