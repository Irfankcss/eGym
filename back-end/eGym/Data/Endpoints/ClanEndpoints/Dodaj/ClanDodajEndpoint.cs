using eGym.Data.Models;
using eGym.Helpers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eGym.Data.Endpoints.ClanEndpoints.Dodaj
{
    [Microsoft.AspNetCore.Mvc.Route("Clan")]
    [Tags("Clan")]
    public class ClanDodajEndpoint : MyBaseEndpoint<ClanDodajRequest,ClanDodajResponse>
    {
        private readonly ApplicationDbContext _context;
        public ClanDodajEndpoint(ApplicationDbContext context)
        {
            this._context = context;
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
                    var novaClanarina = new Clanarina
                    {
                        DatumUplate = DateTime.Now,
                        DatumIsteka = (DateTime.Now).AddDays(30)
                    };

                    Random rnd = new Random();
                    noviclan.BrojClana = rnd.Next(100, 1000);
                    noviclan.Clanarina = novaClanarina;
                    noviclan.KorisnikID = identifikatorKorisnika;
                    noviclan.Vrsta = request.Vrsta;
                    korisnik.isClan = true;
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
