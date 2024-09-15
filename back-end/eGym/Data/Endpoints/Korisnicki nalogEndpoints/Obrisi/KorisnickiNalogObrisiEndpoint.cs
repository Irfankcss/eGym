using eGym.Data.Helpers.Services;
using eGym.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eGym.Data.Controllers.Korisnicki_nalog.Obrisi
{
    [Tags("Korisnicki-nalog")]
    public class KorisnickiNalogObrisiEndpoint : MyBaseEndpoint<KorisnickiNalogObrisiRequest,KorisnickiNalogObrisiResponse>
    {
        public readonly ApplicationDbContext _applicationDbContext;
        public readonly MyAuthService _authService;
        public KorisnickiNalogObrisiEndpoint (ApplicationDbContext applicationDbContext,MyAuthService authService)
        {
            _applicationDbContext = applicationDbContext;
            _authService = authService;
        }
        [HttpDelete]
        public override async Task<KorisnickiNalogObrisiResponse> Obradi([FromQuery] KorisnickiNalogObrisiRequest request, CancellationToken cancellationToken)
        {
            if (!(_authService.isAdmin() && _authService.isLogiran()))
                throw new Exception("Korisnik nema permisiju admina ili nije logiran");
            
            var korisnickiNalozi = _applicationDbContext.KorisnickiNalog.FirstOrDefault(x => x.ID == request.KorisnickiNalogID);

            var korisnickiNalogID = korisnickiNalozi.ID;

            var clanKorisnik = _applicationDbContext.Clan.FirstOrDefault(c=>c.KorisnikID == korisnickiNalogID);
            if(clanKorisnik != null)
            {
                _applicationDbContext.Remove(clanKorisnik);
                await _applicationDbContext.SaveChangesAsync();
            }
            if(korisnickiNalozi == null)
            {
                throw new Exception("Nije pronadjen korisnicki nalog za id= " + request.KorisnickiNalogID);
            }
            var odabraniRadnik = _applicationDbContext.Radnik.Where(r => r.KorisnikID == request.KorisnickiNalogID).FirstOrDefault();
            if (odabraniRadnik != null)
                _applicationDbContext.Radnik.Remove(odabraniRadnik);
            _applicationDbContext.Remove(korisnickiNalozi);
            await _applicationDbContext.SaveChangesAsync();
            return new KorisnickiNalogObrisiResponse
            {

            };
        }
    }
}
