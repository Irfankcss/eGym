using eGym.Data.Helpers.Services;
using eGym.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace eGym.Data.Endpoints.ClanEndpoints.Obrisi
{
    [Tags("Clan")]
    public class ClanObrisiEndpoint : MyBaseEndpoint<ClanObrisiRequest, ClanObrisiResponse>
    {
        private readonly ApplicationDbContext _context;
        public readonly MyAuthService _authService;
        public ClanObrisiEndpoint(ApplicationDbContext context, MyAuthService authService)
        {
            _context = context;
            _authService = authService;
        }
        [HttpDelete]
        public override async Task<ClanObrisiResponse> Obradi([FromQuery]ClanObrisiRequest request, CancellationToken cancellationToken)
        {
            if (!(_authService.isLogiran() && (_authService.isAdmin() ||_authService.isRadnik())))
                throw new Exception("Korisnik nema permisiju admina/radnika ili nije logiran");
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
