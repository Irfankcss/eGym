using eGym.Data;
using eGym.Data.Models;
using eGym.Data.ViewModels.NarudzbaVMs;
using eGym.Data.ViewModels.ProizvodVMs;
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




        //[HttpPost]
        //public async Task<int> DodajNarudzbu(DodajNarudzbuVM dodajnarudzbu)
        //{
        //    var order = new Narudzba
        //    {
        //        DatumKreiranja = dodajnarudzbu.DatumNarudzbe,
        //        Proizvodi=dodajnarudzbu.Proizvodi,
        //        isOdobrena = false,
        //        Vrijednost = dodajnarudzbu.vrijednost,
        //        KorisnikID = dodajnarudzbu.KorisnikID,
        //        Popust = dodajnarudzbu.Popust,
        //        NacinPlacanja = dodajnarudzbu.NacinPlacanja
        //        //NarudzbaProizvodi = dodajnarudzbu.ProizvodIDs.Select(proizvodID => new NarudzbaProizvod
        //        //{
        //        //    ProizvodId = proizvodID,
        //        //}).ToList(),
        //    };
        //    foreach (var item in order.Proizvodi)
        //    {
        //        var proizvod = await _context.Proizvod.FirstOrDefaultAsync(p => p.ProizvodID == item.ProizvodID);
        //        if (proizvod != null)
        //        {

        //            var entry = _context.Entry(proizvod);
        //            if (entry != null)
        //            {
        //                item = proizvod;
        //                //item.ProizvodID = proizvod.ProizvodID;
        //                //item.Brend=proizvod.Brend;
        //                //item.Naziv  = proizvod.Naziv;
        //                //item.Cijena=proizvod.Cijena;
        //                //item.popust = proizvod.popust;
        //                //item.Boja=proizvod.Boja;
        //                //item.BrendID = proizvod.BrendID;
        //                //item.DatumObjave = proizvod.DatumObjave;
        //                //item.isIzdvojen = proizvod.isIzdvojen;
        //                //item.Izbrisan=proizvod.Izbrisan;
        //                //item.Kategorija=proizvod.Kategorija;
        //                //item.KategorijaID = proizvod.KategorijaID;
        //                //item.Velicina=proizvod.Velicina;
        //                //item.Slike=proizvod.Slike;
        //                //item.KolicinaNaSkladistu = proizvod.KolicinaNaSkladistu;
        //                //item.Opis=proizvod.Opis;
        //            }
        //        }
        //    }

        //    _context.Narudzba.Add(order);
        //    await _context.SaveChangesAsync();

        //    return order.Id;
        //}
        //[HttpGet("{id}")]
        //public async Task<ActionResult<NarudzbaVM>> GetNarudzbaById(int id)
        //{
        //    var narudzba = await _context.Narudzba
        //        .Include(n => n.Proizvodi).ThenInclude(p=>p.Proizvod)  // Eagerly load the Proizvodi navigation property
        //        .FirstOrDefaultAsync(n => n.Id == id);

        //    if (narudzba == null)
        //    {
        //        return NotFound(); // Return 404 if the narudzba with the specified id is not found.
        //    }

        //    var narudzbaViewModel = new NarudzbaVM
        //    {
        //        Id = narudzba.Id,
        //        DatumKreiranja = narudzba.DatumKreiranja,
        //        isOdobrena = narudzba.isOdobrena,
        //        Vrijednost = narudzba.Vrijednost,
        //        Popust = narudzba.Popust,
        //        KorisnikID = narudzba.KorisnikID,
        //        NacinPlacanja = narudzba.NacinPlacanja,
        //        Proizvodi = narudzba.Proizvodi.Select(p => new ProizvodVM
        //        {
                    
        //        }).ToList()
        //    };

        //    return Ok(narudzbaViewModel);
        //}
        // GET api/orders/{orderId}
        //   [HttpGet]
        // public async Task<IActionResult> GetNarudzbe()
        // {
        //     var narudzbe = await _context.Narudzba
        //         .Include(n => n.NarudzbaProizvodi) 
        //             .ThenInclude(np => np.Proizvod)
        //         .Include(n => n.korisnik)         
        //         .ToListAsync();
        //
        //     return Ok(narudzbe);
        // }

        // [HttpGet("by id")]
        // public IActionResult GetNarudzbaById(int NarudzbaID)
        // {
        //     var rezultat = _context.Narudzba.Where(x => NarudzbaID == null || x.Id == NarudzbaID).Select(x => new Narudzba
        //     {
        //         Id = x.Id,
        //         DatumKreiranja = x.DatumKreiranja,
        //         KorisnikID = x.KorisnikID,
        //         korisnik = x.korisnik,
        //         isOdobrena = x.isOdobrena,
        //         NacinPlacanja = x.NacinPlacanja,
        //         Popust = x.Popust,
        //         Vrijednost = x.Vrijednost,
        //         NarudzbaProizvodi = x.NarudzbaProizvodi
        //     }).ToList();
        //     return Ok(rezultat);
        // }
    }
}


//var rezultat = _applicationDbContext
//              .Ispit
//              .Where(x => naziv == null || x.Predmet.Naziv.ToLower().StartsWith(naziv.ToLower()))
//              .Select(x => new IspitGet
//              {
//                  IdIspita = x.ID,
//                  Komnt = x.Komentar,
//                  Satnica = x.DatumVrijemeIspita,
//                  PredmetId = x.PredmetID,
//                  PuniNaziv = x.Predmet.Naziv,
//                  SifraPredmeta = x.Predmet.Sifra,
//                  Bodovi = x.Predmet.Ects
//              }).ToList();

//return Ok(rezultat);