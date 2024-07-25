using eGym.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace eGym.Data.Controllers.Korisnicki_nalog.Obrisi
{
    [Tags("Korisnicki-nalog")]
    public class KorisnickiNalogObrisiEndpoint : MyBaseEndpoint<KorisnickiNalogObrisiRequest,KorisnickiNalogObrisiResponse>
    {
        public readonly ApplicationDbContext _applicationDbContext;
        public KorisnickiNalogObrisiEndpoint (ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpDelete]
        public override async Task<KorisnickiNalogObrisiResponse> Obradi([FromQuery] KorisnickiNalogObrisiRequest request, CancellationToken cancellationToken)
        {
            var korisnickiNalozi = _applicationDbContext.KorisnickiNalog.FirstOrDefault(x => x.ID == request.KorisnickiNalogID);
            if(korisnickiNalozi == null)
            {
                throw new Exception("Nije pronadjen korisnicki nalog za id= " + request.KorisnickiNalogID);
            }
            _applicationDbContext.Remove(korisnickiNalozi);
            await _applicationDbContext.SaveChangesAsync();
            return new KorisnickiNalogObrisiResponse
            {

            };
        }
    }
}
