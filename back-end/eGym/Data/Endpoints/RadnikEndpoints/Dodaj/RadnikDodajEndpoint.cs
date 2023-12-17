using eGym.Data.Models;
using eGym.Helper;
using Microsoft.AspNetCore.Mvc;

namespace eGym.Data.Endpoints.RadnikEndpoints.Dodaj
{
    [Route("Radnik")]
    [Tags("Radnik")]
    public class RadnikDodajEndpoint : MyBaseEndpoint<RadnikDodajRequest,int>
    {
        private readonly ApplicationDbContext _context;

        public RadnikDodajEndpoint(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("Dodaj Radnika")]
        public override async Task<int> Obradi([FromQuery]RadnikDodajRequest request, CancellationToken cancellationToken)
        {
            var radnik = new Radnik();


                radnik.Ime = request.Ime;
                radnik.Prezime = request.Prezime;
                radnik.Spol = request.Spol;
                radnik.DatumRodjenja = request.DatumRodjenja;
                radnik.DatumZaposlenja = request.DatumZaposlenja;
                radnik.BrojTelefona = request.BrojTelefona;
                radnik.GradID = request.GradID;
                radnik.KorisnickoIme = request.KorisnickiNalog.KorisnickoIme;
                radnik.Email = request.KorisnickiNalog.Email;
                radnik.Lozinka = request.KorisnickiNalog.Lozinka;
                radnik.Slika = request.KorisnickiNalog.Slika;
                radnik.isAdmin = request.KorisnickiNalog.isAdmin;
                radnik.isRadnik = request.KorisnickiNalog.isRadnik;
                radnik.isKorisnik = request.KorisnickiNalog.isKorisnik;
            

            
            _context.Radnik.Add(radnik);
            await _context.SaveChangesAsync();
            return radnik.ID;
        }
    }
}
