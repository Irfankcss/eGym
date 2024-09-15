using eGym.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace eGym.Data.Endpoints.Korisnik.Obrisi
{
    [Tags("Korisnik")]
    public class KorisnikObrisiEndpoint : MyBaseEndpoint<KorisnikObrisiRequest, KorisnikObrisiResponse>
    {
        public readonly ApplicationDbContext _applicationDbContext;
        public KorisnikObrisiEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpDelete]
        public override async Task<KorisnikObrisiResponse> Obradi([FromQuery] KorisnikObrisiRequest request, CancellationToken cancellationToken)
        {
            var korisnici = _applicationDbContext.Korisnik.FirstOrDefault(x => x.ID == request.KorisnikID);
            if (korisnici == null)
            {
                throw new Exception("Nije pronadjen korisnik za id= " + request.KorisnikID);
            }
            _applicationDbContext.Remove(korisnici);
            await _applicationDbContext.SaveChangesAsync();
            return new KorisnikObrisiResponse
            {

            };
        }
    }
}
