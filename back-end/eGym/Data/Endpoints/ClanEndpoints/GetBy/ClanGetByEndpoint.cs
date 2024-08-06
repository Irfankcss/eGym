using eGym.Data.Endpoints.ClanEndpoints.GetAll;
using eGym.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static eGym.Data.Endpoints.ClanEndpoints.GetBy.ClanGetByResponse;

namespace eGym.Data.Endpoints.ClanEndpoints.GetBy
{
    [Tags("Clan")]
    public class ClanGetByEndpoint : MyBaseEndpoint<ClanGetByRequest, ClanGetByResponse>
    {
        private readonly ApplicationDbContext _context;
        public ClanGetByEndpoint(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("GetByID")]
        public override async Task<ClanGetByResponse> Obradi([FromQuery]ClanGetByRequest request, CancellationToken cancellationToken)
        {
            var logiraniKorisnik = _context.AutentifikacijaToken.FirstOrDefault();
            if (logiraniKorisnik == null)
                throw new Exception("Korisnik nije logiran");
            var logiraniKorisnikID = logiraniKorisnik.KorisnickiNalogId;
            var provjeraClan = _context.KorisnickiNalog.Where(kn => kn.ID == logiraniKorisnikID).FirstOrDefault();
            if (provjeraClan == null)
                throw new Exception("Korisnik nije pronađen");
            var provjeraClanisClan = provjeraClan.isClan;
            if (provjeraClanisClan == false)
                throw new Exception("Logirani korisnik nije član teretane");

            var clan = await _context.Clan.Where(c => c.KorisnikID == logiraniKorisnikID).Select(x => new ClanGetByResponseClan()
            {
                Ime = x.Korisnik.Ime,
                Prezime = x.Korisnik.Prezime,
                BrojClana = x.BrojClana,
                Vrsta = x.Vrsta,
                DatumUplate = DateOnly.FromDateTime(x.Clanarina.DatumUplate),
                DatumIsteka = DateOnly.FromDateTime(x.Clanarina.DatumIsteka)
            }).ToListAsync();
            return new ClanGetByResponse
            { 
                Clanovi = clan
            };
        }
    }
}
