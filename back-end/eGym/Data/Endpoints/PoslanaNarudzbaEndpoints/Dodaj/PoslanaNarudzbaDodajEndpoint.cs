using eGym.Data.Helpers.Services;
using eGym.Data.Models;
using eGym.Helpers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eGym.Data.Endpoints.PoslanaNarudzbaEndpoints.Dodaj
{
    [Microsoft.AspNetCore.Mvc.Route("PoslanaNarudzba")]
    [Tags("Poslana Narudzba")]
    public class PoslanaNarudzbaDodajEndpoint : MyBaseEndpoint<PoslanaNarudzbaDodajRequest, int>
    {
        private readonly ApplicationDbContext _context;
        private readonly MyAuthService _authService;
        private readonly EmailSender _emailSender;
        public PoslanaNarudzbaDodajEndpoint(ApplicationDbContext context, MyAuthService myAuthService, EmailSender emailSender)
        {
            _context = context;
            _authService = myAuthService;
            _emailSender = emailSender;
        }

       
        [HttpPost("Posalji narudzbu")]
        public override async Task<int> Obradi(PoslanaNarudzbaDodajRequest request, CancellationToken cancellationToken)
        {

            var _radnik = await _context.Radnik.FirstOrDefaultAsync(r => r.KorisnikID == request.RadnikID);
            var narudzba = await _context.Narudzba.AsNoTracking().Include(k=>k.korisnik).FirstAsync(n => n.Id == request.NarudzbaID);


            if (_radnik == null || narudzba == null)
            {
                throw new Exception("radnik ili narudzba ne postoje");
            }
            
            if (narudzba.isPoslana) { throw new Exception("Narudzba je vec poslana"); }

            var noviobj = new PoslanaNarudzba
            {
                NarudzbaID = request.NarudzbaID,
                DatumSlanja = DateTime.Now,
                Radnik=_radnik,
                isIsporucena = false,
                isPreuzeta = false,
            };
            narudzba.isPoslana = true;
            _context.Narudzba.Update(narudzba);
            await _context.SaveChangesAsync();

            
            _context.PoslanaNarudzba.Add(noviobj);
            await _context.SaveChangesAsync();

            _emailSender.Posalji2(
             narudzba.Email,
             "Obavijest o slanju narudžbe #" + narudzba.Id,
             "Poštovani/Poštovana,\n\n" +
             "Sa zadovoljstvom vas obavještavamo da je vaša narudžba s brojem #" + narudzba.Id + " uspješno poslana.\n\n" +
             "Vaša pošiljka je na putu prema vama, te će uskoro stići na navedenu adresu. Očekivani rok isporuke je u narednih nekoliko dana. Molimo vas da budete dostupni za preuzimanje pošiljke.\n\n" +
             "<hr>" +
             "Ako imate bilo kakva pitanja ili trebate dodatne informacije, slobodno nas kontaktirajte.\n\n" +
             "Hvala vam što ste odabrali našu uslugu i nadamo se da ćete biti zadovoljni vašom narudžbom.\n\n" +
             "Srdačan pozdrav,\n" +
             "Vaš tim"
              );
            return noviobj.PoslanaNarudzbaID;
        }
    }
}
