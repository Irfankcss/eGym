using eGym.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace eGym.Data.Controllers.Kreditna_kartica.Obrisi
{
    [Tags("Kreditna-kartica")]
    public class KreditnaKarticaObrisiEndpoint : MyBaseEndpoint<KreditnaKarticaObrisiRequest,KreditnaKarticaObrisiResponse>
    {
        public readonly ApplicationDbContext _applicationDbContext;
        public KreditnaKarticaObrisiEndpoint (ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpDelete]
        public override async Task<KreditnaKarticaObrisiResponse> Obradi([FromQuery]KreditnaKarticaObrisiRequest request, CancellationToken cancellationToken)
        {
            var kartice = _applicationDbContext.KreditnaKartica.FirstOrDefault(x => x.ID == request.KreditnaKarticaID);
            if(kartice== null)
            {
                throw new Exception("Nije pronadjena kartica za id= " + request.KreditnaKarticaID);
            }
            _applicationDbContext.Remove(kartice);
            await _applicationDbContext.SaveChangesAsync();
            return new KreditnaKarticaObrisiResponse
            {

            };
        }
    }
}
