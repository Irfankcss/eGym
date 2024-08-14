using eGym.Data.Helpers;
using eGym.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace eGym.Data.Endpoints.ClanEndpoints.ClanIzmjeniStatus
{
    [Tags("Clan")]
    public class ClanIzmjeniStatusEndpoint : MyBaseEndpoint<ClanIzmjeniStatusRequest, NoResponse>
    {
        private readonly ApplicationDbContext _context;
        public ClanIzmjeniStatusEndpoint(ApplicationDbContext context)
        {
            this._context = context;
        }
        [HttpPost]
        public override async Task<NoResponse> Obradi([FromQuery]ClanIzmjeniStatusRequest request, CancellationToken cancellationToken)
        {
            var korisnik = _context.KorisnickiNalog.Where(kn=>kn.ID == request.ClanID).FirstOrDefault();
            if(korisnik == null){
                throw new Exception("Korisnik nije pronađen");
            }
            korisnik.isClan = false;
            await _context.SaveChangesAsync();
            return new NoResponse
            {

            };

        }
    }
}
