using eGym.Data.Models;
using eGym.Helper;
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
            var korisnik = await _context.Korisnik.FirstOrDefaultAsync(x => x.ID == request.KorisnikID);
            var noviclan = new Clan();

            if (korisnik != null)
            {
                if (!korisnik.isClan)
                {
                    Random rnd = new Random();
                    noviclan.BrojClana = rnd.Next(100, 1000);
                    noviclan.ClanarinaID = request.ClanarinaID;
                    noviclan.KorisnikID = request.KorisnikID;

                    korisnik.isClan = true;

                }
                else throw new Exception("Korisnik je vec clan");

            }
            else throw new Exception("Nepostojeci korisnik");
            await _context.Clan.AddAsync(noviclan, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return new ClanDodajResponse
            {
                BrojClana = noviclan.BrojClana,
                Korisnik = noviclan.Korisnik
            };
        }
    }
}
