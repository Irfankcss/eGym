using eGym.Data.Models;
using eGym.Data;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Net.WebRequestMethods;

[ApiController]
[Route("[controller]/[action]")]
[Tags("-Podaci-")]

public class PodaciController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public PodaciController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    [HttpPost]
    public ActionResult Generisi()
    {             
        Random r = new Random();
        //drzave
        var drzave = _dbContext.Drzava.ToList();
        if (drzave.Count < 1)
        {
            _dbContext.Drzava.Add(new Drzava { Naziv = "BiH", Skracenica = "BiH" });
            _dbContext.Drzava.Add(new Drzava { Naziv = "HR", Skracenica = "HR" });
            _dbContext.Drzava.Add(new Drzava { Naziv = "Njemačka", Skracenica = "GER" });
            _dbContext.Drzava.Add(new Drzava { Naziv = "Austrija", Skracenica = "AU" });
        }
        _dbContext.SaveChanges();
        //gradovi
        var gradovi = _dbContext.Grad.ToList();
        if (gradovi.Count < 1)
        {
            _dbContext.Grad.Add(new Grad { Naziv = "Sarajevo", DrzavaID = 1, PostanskiBroj = "71000" });
            _dbContext.Grad.Add(new Grad { Naziv = "Mostar", DrzavaID = 1, PostanskiBroj = "88000" });
            _dbContext.Grad.Add(new Grad { Naziv = "Zagreb", DrzavaID = 2, PostanskiBroj = "71000" });
            _dbContext.Grad.Add(new Grad { Naziv = "Berlin", DrzavaID = 3, PostanskiBroj = "33333" });
            _dbContext.Grad.Add(new Grad { Naziv = "Zurich", DrzavaID = 4, PostanskiBroj = "10000" });
        }
        _dbContext.SaveChanges();
        var kategorije = _dbContext.Kategorija.ToList();
        if (kategorije.Count < 1)
        {
            _dbContext.Kategorija.Add(new Kategorija { NazivKategorije = "Suplementi", Opis = "Suplementi, dodaci ishrani, proteini, mass gaineri..." });
            _dbContext.Kategorija.Add(new Kategorija { NazivKategorije = "Dodaci", Opis = "Dodaci i pomagala za trening i sportske aktivnosti" });
            _dbContext.Kategorija.Add(new Kategorija { NazivKategorije = "Odjeća", Opis = "Sportski odjevni predmeti za sve spolove i uzraste" });
        }
        _dbContext.SaveChanges();
        var brendovi = _dbContext.Brend.ToList();
        if (brendovi.Count < 1)
        {
            _dbContext.Brend.Add(new Brend { NazivBrenda = "Pure Gold" });
            _dbContext.Brend.Add(new Brend { NazivBrenda = "Gym Beam" });
            _dbContext.Brend.Add(new Brend { NazivBrenda = "Addidas" });
            _dbContext.Brend.Add(new Brend { NazivBrenda = "Nike" });
            _dbContext.Brend.Add(new Brend { NazivBrenda = "Bolde" });
        }
        _dbContext.SaveChanges();
        var admini = _dbContext.Admin.ToList();
        if (admini.Count < 1)
        {

            _dbContext.Admin.Add(new Admin { AdminKod = r.Next(1000, 100000).ToString(), Email = "ahmed@gmail.com", isAdmin = true, KorisnickoIme = "ahmed_g", Lozinka = "0000", Slika = "empty.png",isClan = false });
            _dbContext.Admin.Add(new Admin { AdminKod = r.Next(1000, 100000).ToString(), Email = "admir@gmail.com", isAdmin = true, KorisnickoIme = "admir_admin", Lozinka = "0000", Slika = "empty.png", isClan = false });
        }
        _dbContext.SaveChanges();

        var obavjesti = _dbContext.Obavjesti.ToList();
        if (obavjesti.Count < 1)
        {
            _dbContext.Obavjesti.Add(new Obavjesti { DatumObjave = DateTime.Now, Naslov = "Novi proteini u ponudi", Text = "Ukusni proteini samo za tebe :3", AdminID = 2, Slika = "https://media.post.rvohealth.io/wp-content/uploads/2023/11/3256105-18_Best_Protein_Powders_by_Type_According_to_a_Dietitian-1200x628-Facebook.jpg", isHidden = false});
            _dbContext.Obavjesti.Add(new Obavjesti { DatumObjave = DateTime.Now, Naslov = "Akcije na članarinu", Text = "Akcije na godišnju članarinu 20% do kraja mjeseca", AdminID = 2, Slika = "https://www.fitness.com.hr/images/articles/trener-veslanje.jpg", isHidden = false });
        }
        _dbContext.SaveChanges();
        var korisnici = _dbContext.Korisnik.ToList();
        if (korisnici.Count < 1)
        {
            _dbContext.Korisnik.Add(new Korisnik
            {
                Ime = "Tarik",
                Prezime = "Šabić",
                BrojTelefona = "225883",
                DatumRodjenja = DateTime.Now,
                Email = "porodicasabic@hotmail.com",
                isKorisnik = true,
                isClan = true,
                KorisnickoIme = "little.saba",
                Lozinka = "1234",
                OpstinaRodjenjaID = 2,
                Spol = "M",
                Slika = "https://png.pngtree.com/png-vector/20230318/ourmid/pngtree-duck-wild-animal-transparent-on-white-background-png-image_6655631.png"
            }); _dbContext.Korisnik.Add(new Korisnik
            {
                Ime = "Tarik",
                Prezime = "Sarać",
                BrojTelefona = "2258843",
                DatumRodjenja = DateTime.Now,
                Email = "saracmal@hotmail.com",
                isKorisnik = true,
                isClan = true,
                KorisnickoIme = "tarik.sarac",
                Lozinka = "1234",
                OpstinaRodjenjaID = 1,
                Spol = "M",
                Slika = "https://png.pngtree.com/png-vector/20230318/ourmid/pngtree-duck-wild-animal-transparent-on-white-background-png-image_6655631.png"
            }); _dbContext.Korisnik.Add(new Korisnik
            {
                Ime = "Amina",
                Prezime = "Mlina",
                BrojTelefona = "2258843",
                DatumRodjenja = DateTime.Now,
                Email = "aminica@gmail.com",
                isKorisnik = true,
                isClan = false,
                KorisnickoIme = "amina.sar",
                Lozinka = "1234",
                OpstinaRodjenjaID = 3,
                Spol = "Ž",
                Slika = "https://png.pngtree.com/png-vector/20230318/ourmid/pngtree-duck-wild-animal-transparent-on-white-background-png-image_6655631.png"
            });
        }
        _dbContext.SaveChanges();
        var clanarina = _dbContext.Clanarina.ToList();
        var clanarine = new List<Clanarina>();
        if (clanarina.Count < 1)
        {
            clanarine.Add(new Clanarina { DatumIsteka = DateTime.Now, DatumUplate = DateTime.Now, });
            clanarine.Add(new Clanarina { DatumIsteka = DateTime.Now, DatumUplate = DateTime.Now, });
            _dbContext.Clanarina.AddRange(clanarine);
        }
        _dbContext.SaveChanges();
        var clanovi = _dbContext.Clan.ToList();
        var clanovii = new List<Clan>();
        if(clanovi.Count < 1)
        {
            clanovii.Add(new Clan { BrojClana = r.Next(1300, 13000), Vrsta="VIP", ClanarinaID = 1, KorisnikID = 3 });
            clanovii.Add(new Clan { BrojClana = r.Next(1300, 13000), Vrsta="Student poludnevna", ClanarinaID = 2, KorisnikID = 4 });
            _dbContext.Clan.AddRange(clanovii);
        }
        _dbContext.SaveChanges();
        var proizvodi = _dbContext.Proizvod.ToList();
        if (proizvodi.Count < 1)
        {
            _dbContext.Proizvod.Add(new Proizvod
            {
                Naziv = "Pure Gold Whey",
                Boja = "Neutral",
                BrendID = 1,
                KategorijaID = 1,
                Cijena = 70.00,
                DatumObjave = DateTime.Now,
                KolicinaNaSkladistu = 29,
                Opis = "Super Whey protein isolate 1kg",
                popust = 10,
                Velicina = "none",
                Slike = { new Slika { Putanja = "https://elitnutrition.ba/wp-content/uploads/2023/10/pgp-whey-1000g.png" }, new Slika { Putanja = "https://d4n0y8dshd77z.cloudfront.net/listings/49683227/lg/yZJuQ6AMVqi2cOTUBSS5.jpg" } }
            });
            _dbContext.Proizvod.Add(new Proizvod {
                Naziv = "Gym Beam Creatine",
                Boja = "Neutral",
                BrendID = 2,
                KategorijaID = 1,
                Cijena = 35.00,
                DatumObjave = DateTime.Now,
                KolicinaNaSkladistu = 29,
                Opis = "Creatine 100% Monohydrate 250g Mango-Maracuja",
                popust = 0,
                Velicina = "none",
                Slike = { new Slika { Putanja = "https://gymbeam.ba/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/c/r/creatine_monohydrate_mango-maracuja_250_g_gymbeam.png" } }
            });
            _dbContext.Proizvod.Add(new Proizvod
            {
                Naziv = "Harden Vol 7",
                Boja = "Narandžasta",
                BrendID = 3,
                KategorijaID = 3,
                Cijena = 235.00,
                DatumObjave = DateTime.Now,
                KolicinaNaSkladistu = 29,
                Opis = "Addidas patike za košarku",
                popust = 15,
                Velicina = "43",
                Slike = { new Slika { Putanja = "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/b76009337ba04983baedafcb0114c6f5_9366/Harden_Vol._7_Shoes_Orange_ID2237_01_standard.jpg" }
                , new Slika{ Putanja="https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/c4a944cdd55340259da5afcb01169277_9366/Harden_Vol._7_Shoes_Orange_ID2237_04_standard.jpg"},
                new Slika { Putanja="https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/3912d2fd2420456d98e4afcb01154b02_9366/Harden_Vol._7_Shoes_Orange_ID2237_03_standard.jpg"}}
            }) ;
            _dbContext.Proizvod.Add(new Proizvod
            {
                Naziv = "Bolde Protein Shaker",
                Boja = "Crna",
                BrendID = 5,
                KategorijaID = 2,
                Cijena = 30.00,
                DatumObjave = DateTime.Now,
                KolicinaNaSkladistu = 29,
                Opis = "Super shaker za miksanje proteina",
                popust = 25,
                Velicina = "none",
                Slike = { new Slika { Putanja = "https://boldebottle.com/cdn/shop/products/619832e18bc20d848e890195_BOLDE-Bottle-Black-Side_2048x.png?v=1638403556" }, new Slika { Putanja = "https://cdn.shopify.com/s/files/1/0279/7482/8116/files/BOLDE-Bottle-Black-Steel-Mixer.jpg?v=1658444672&width=2048" },
                new Slika { Putanja="https://cdn.shopify.com/s/files/1/0279/7482/8116/files/BOLDE-Bottle-Black-Open.jpg?v=1658444672&width=2048"} }
            });
        }
        _dbContext.SaveChanges();
        var radnici = _dbContext.Radnik.ToList();
        if(radnici.Count < 1)
        {
            _dbContext.Radnik.Add(new Radnik
            {
                isRadnik = true,
                Ime = "Kerim",
                Prezime = "Muderizović",
                Email = "jolinecaroline@gmail.com",
                BrojTelefona = "061334231",
                DatumRodjenja = DateTime.Now,
                DatumZaposlenja = DateTime.Now,
                GradID = 4,
                KorisnickoIme = "kerim.abs",
                Lozinka = "Random",
                Slika = "https://cdn.shopify.com/s/files/1/0279/7482/8116/files/BOLDE-Bottle-Black-Open.jpg?v=1658444672&width=2048",
                Spol = "M",
                isClan = false
            });
            _dbContext.Radnik.Add(new Radnik
            {
                isRadnik = true,
                Ime = "Lamija",
                Prezime = "Torlović",
                Email = "ltorlovic@edu.fit.ba",
                BrojTelefona = "061394231",
                DatumRodjenja = DateTime.Now,
                DatumZaposlenja = DateTime.Now,
                GradID = 4,
                KorisnickoIme = "lamija.sda",
                Lozinka = "Random",
                Slika = "https://cdn.shopify.com/s/files/1/0279/7482/8116/files/BOLDE-Bottle-Black-Open.jpg?v=1658444672&width=2048",
                Spol = "Ž",
                isClan = false
            });
            _dbContext.SaveChanges();
        }
        return Ok();
    }

}
