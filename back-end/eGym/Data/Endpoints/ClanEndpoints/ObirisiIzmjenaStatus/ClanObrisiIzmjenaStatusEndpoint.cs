using eGym.Data.Endpoints.ClanEndpoints.Obrisi;
using eGym.Data.Models;
using eGym.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace eGym.Data.Endpoints.ClanEndpoints.ObirisiIzmjenaStatus
{
    [Tags("Clan")]
    public class ClanObrisiIzmjenaStatusEndpoint : MyBaseEndpoint<ClanObrisiIzmjenaStatusRequest, ClanObrisiIzmjenaStatusResponse>
    {
        private readonly ApplicationDbContext _context;
        public ClanObrisiIzmjenaStatusEndpoint(ApplicationDbContext context)
        {
            this._context = context;
        }
        [HttpDelete]
        public override async Task<ClanObrisiIzmjenaStatusResponse> Obradi([FromQuery]ClanObrisiIzmjenaStatusRequest request, CancellationToken cancellationToken)
        {
            var korisnikUClanu = _context.Clan.Where(c => c.KorisnikID == request.KorisnikID).FirstOrDefault();
            if (korisnikUClanu == null)
                throw new Exception("Korisnik nije pronađen");

            _context.Remove(korisnikUClanu);
            await _context.SaveChangesAsync();


            return new ClanObrisiIzmjenaStatusResponse
            {

            };
        }
    }
}
