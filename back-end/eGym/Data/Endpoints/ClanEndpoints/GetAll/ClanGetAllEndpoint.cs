using eGym.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static eGym.Data.Endpoints.ClanEndpoints.GetAll.ClanGetAllResponse;

namespace eGym.Data.Endpoints.ClanEndpoints.GetAll
{
    [Route("Clan")]
    [Tags("Clan")]
    public class ClanGetAllEndpoint : MyBaseEndpoint<ClanGetAllRequest, ClanGetAllResponse>
    {
        private readonly ApplicationDbContext _context;

        public ClanGetAllEndpoint(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("GetAll")]
        public override async Task<ClanGetAllResponse> Obradi([FromQuery]ClanGetAllRequest request, CancellationToken cancellationToken)
        {
            var clanovi = await _context.Clan.Select(x => new ClanGetAllResponseClan()
            {
                ID = x.ClanID,
                Ime = x.Korisnik.Ime,
                Prezime = x.Korisnik.Prezime,
                VrstaMjesecne = x.Vrsta,
                BrojClana = x.BrojClana,
                DatumUplate = DateOnly.FromDateTime(x.Clanarina.DatumUplate),
                DatumIsteka = DateOnly.FromDateTime(x.Clanarina.DatumIsteka)
            }).ToListAsync();

            return new ClanGetAllResponse
            {
                clanovi = clanovi
            };
        }
    }
}
