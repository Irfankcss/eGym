using eGym.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace eGym.Data.Endpoints.ClanEndpoints.Obrisi
{
    [Tags("Clan")]
    public class ClanObrisiEndpoint : MyBaseEndpoint<ClanObrisiRequest, ClanObrisiResponse>
    {
        private readonly ApplicationDbContext _context;
        public ClanObrisiEndpoint(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpDelete]
        public override async Task<ClanObrisiResponse> Obradi([FromQuery]ClanObrisiRequest request, CancellationToken cancellationToken)
        {
            var clan = _context.Clan.Where(c=>c.ClanID == request.ClanID).FirstOrDefault();
            if (clan == null)
                throw new Exception("Clan ne postoji");

            _context.Remove(clan);
            await _context.SaveChangesAsync();

            return new ClanObrisiResponse
            {

            };
        }
    }
}
