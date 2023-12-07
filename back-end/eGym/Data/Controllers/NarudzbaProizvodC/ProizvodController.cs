using eGym.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [HttpGet("{productId}/orders")]
        public IActionResult GetOrdersForProduct(int ProizvodID)
        {
            var ordersForProduct = _context.NarudzbaProizvod
                .Where(np => np.ProizvodId == ProizvodID)
                .Select(np => np.proizvod) 
                .ToList();
        
            return Ok(ordersForProduct);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProizvod(int id)
        {
            var proizvod = await _context.Proizvod.FindAsync(id);

            if (proizvod == null)
            {
                return NotFound("Proizvod not found");
            }

            return Ok(proizvod);
        }
        [HttpGet("{NarudzbaID}")]
        public List<Proizvod> GetProizvodNarudzbe(int NarudzbaID)
        {
            var narudzbap =  _context.NarudzbaProizvod.Where(x=>x.NarudzbaId==NarudzbaID).ToList();
            List < Proizvod > proizvodi= new List<Proizvod>();
            foreach(NarudzbaProizvod np in narudzbap)
            {
                proizvodi.Add(np.proizvod);
            }
            if (proizvodi.Count() == 0)
            {
                throw (new Exception("nema proizvoda u toj narudzbi"));
            }

            return proizvodi;
        }
        [HttpPost]
        public async Task<IActionResult> PostProizvod(Proizvod proizvod)
        {
            _context.Proizvod.Add(proizvod);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProizvod), new { id = proizvod.ProizvodID }, proizvod);
        }
    }
}
