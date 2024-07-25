using eGym.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eGym.Data.Endpoints.ClanEndpoints.GetAll
{
    [Route("Clan")]
    [Tags("Clan")]
    public class ClanGetAllEndpoint : MyBaseEndpoint<ClanGetAllRequest, List<ClanGetAllResponse>>
    {
        private readonly ApplicationDbContext _context;

        public ClanGetAllEndpoint(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public override async Task<List<ClanGetAllResponse>> Obradi([FromQuery]ClanGetAllRequest request, CancellationToken cancellationToken)
        {
            var clanovi = await _context.Clan.Select(x =>
            new ClanGetAllResponse {
                BrojClana = x.BrojClana,
                ClanarinaID = x.ClanarinaID,
                ClanID = x.ClanID,
                KorisnikID = x.KorisnikID,
                Korisnik=x.Korisnik }).ToListAsync();
            if (clanovi == null)
                throw new Exception("Nema clanova ili je greska");
            return clanovi;
        }
        
    }
}
