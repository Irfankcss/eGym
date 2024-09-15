using eGym.Data.Helpers.Services;
using eGym.Data.Models;
using eGym.Helpers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.Xml;

namespace eGym.Data.Endpoints.ClanEndpoints.Dodaj
{
    [Microsoft.AspNetCore.Mvc.Route("Clan")]
    [Tags("Clan")]
    public class ClanDodajEndpoint : MyBaseEndpoint<ClanDodajRequest,ClanDodajResponse>
    {
        private readonly ApplicationDbContext _context;
        private readonly EmailSender _emailSender;
        public ClanDodajEndpoint(ApplicationDbContext context,EmailSender emailSender)
        {
            this._context = context;
            _emailSender = emailSender;

        }

        [HttpPost("Dodaj")]
        public override async Task<ClanDodajResponse> Obradi(ClanDodajRequest request, CancellationToken cancellationToken)
        {
            var logiraniKorisnik = _context.AutentifikacijaToken.FirstOrDefault();
            if(logiraniKorisnik == null){
                throw new Exception("Korisnik nije logiran");
            }
            
            var identifikatorKorisnika = logiraniKorisnik.KorisnickiNalogId;
            var korisnik = await _context.Korisnik.FirstOrDefaultAsync(x => x.ID == identifikatorKorisnika);
            var noviclan = new Clan();

            if (korisnik != null)
            {
                if (!korisnik.isClan)
                {
                   var novaClanarina = new Models.Clanarina
                    {
                        DatumUplate = DateTime.Now,
                        DatumIsteka = (DateTime.Now).AddDays(30)
                    };
                    var logiraniKorisnikEmail = logiraniKorisnik.korisnickiNalog.Email;
                    Random rnd = new Random();
                    noviclan.BrojClana = rnd.Next(100, 1000);
                    noviclan.Clanarina = novaClanarina;
                    noviclan.KorisnikID = identifikatorKorisnika;
                    noviclan.Vrsta = request.Vrsta;
                    korisnik.isClan = true;

                    _emailSender.Posalji(logiraniKorisnikEmail);
                }
                else throw new Exception("Korisnik je vec clan");

            }
            else throw new Exception("Nepostojeci korisnik");
            await _context.Clan.AddAsync(noviclan, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            

            return new ClanDodajResponse
            {

            };
        }
    }
}
