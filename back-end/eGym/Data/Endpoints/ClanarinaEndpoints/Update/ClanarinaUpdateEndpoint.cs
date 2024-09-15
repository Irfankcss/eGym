using eGym.Data.Helpers.Services;
using eGym.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace eGym.Data.Endpoints.Clanarina.Update
{
    [Tags("Clanarina")]
    public class ClanarinaUpdateEndpoint : MyBaseEndpoint<ClanarinaUpdateRequest, ClanarinaUpdateResponse>
    {
        public readonly ApplicationDbContext _applicationDbContext;
        public readonly MyAuthService _authService;
        public ClanarinaUpdateEndpoint(ApplicationDbContext applicationDbContext, MyAuthService authService)
        {
            _applicationDbContext = applicationDbContext;
            _authService = authService;
        }
        [HttpPost]
        public override async Task<ClanarinaUpdateResponse> Obradi([FromBody] ClanarinaUpdateRequest request, CancellationToken cancellationToken)
        {
            if (!(_authService.isLogiran() && (_authService.isAdmin() || _authService.isRadnik())))
                throw new Exception("Korisnik nema permisiju admina/radnika ili nije logiran");

            var clanarina = _applicationDbContext.Clanarina.FirstOrDefault(x => x.ID == request.ClanarinaId);
            if (clanarina == null)
            {
                throw new Exception("Nema clanarine za id= " + request.ClanarinaId);
            }
            DateTime izracunatiDatum = DateTime.Now;
            clanarina.DatumUplate = DateTime.Now;
            clanarina.DatumIsteka = izracunatiDatum.AddDays(30);
            await _applicationDbContext.SaveChangesAsync();
            return new ClanarinaUpdateResponse
            {
                ClanarinaID = clanarina.ID,
                DatumUplate = clanarina.DatumUplate,
                DatumIsteka = clanarina.DatumIsteka
            };
        }
    }
}
