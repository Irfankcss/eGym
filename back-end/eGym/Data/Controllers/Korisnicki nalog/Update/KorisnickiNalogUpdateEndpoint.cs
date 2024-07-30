using eGym.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace eGym.Data.Controllers.Korisnicki_nalog.Update
{
    [Tags("Korisnicki-nalog")]
    public class KorisnickiNalogUpdateEndpoint : MyBaseEndpoint<KorisnickiNalogUpdateRequest, KorisnickiNalogUpdateResponse>
    {
        public readonly ApplicationDbContext _applicationDbContext;
        public KorisnickiNalogUpdateEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpPost]
        public override async Task<KorisnickiNalogUpdateResponse> Obradi([FromBody]KorisnickiNalogUpdateRequest request, CancellationToken cancellationToken)
        {
            var korisnickiNalog = _applicationDbContext.KorisnickiNalog.FirstOrDefault(x=>x.ID == request.KorisnickiNalogID);
            if(korisnickiNalog == null)
            {
                throw new Exception("Ne postoji korisnicki nalog za Id= " + request.KorisnickiNalogID);
            }

            if(korisnickiNalog.isKorisnik == true && request.isRadnik == true)
            {
                korisnickiNalog.isRadnik = request.isRadnik;
                korisnickiNalog.isKorisnik = false;
            }
            if(korisnickiNalog.isRadnik == true && request.isKorisnik == true)
            {
                korisnickiNalog.isKorisnik = request.isKorisnik;
                korisnickiNalog.isRadnik = false;
            }
            await _applicationDbContext.SaveChangesAsync();
            return new KorisnickiNalogUpdateResponse
            {
                KorisnickiNalogID = request.KorisnickiNalogID
            };
        }
    }
}
