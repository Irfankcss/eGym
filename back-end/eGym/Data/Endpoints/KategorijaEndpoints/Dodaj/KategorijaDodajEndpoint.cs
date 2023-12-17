using eGym.Helper;
using eGym.Data.Models;
using eGym.Data.Endpoints.KategorijaEndpoints.Dodaj;
using Microsoft.AspNetCore.Mvc;

namespace eGym.Data.Endpoints.Kategorija.Dodaj
{
    [Route("Kategorija")]
    [Tags("Kategorija")]
    public class KategorijaDodajEndpoint : MyBaseEndpoint<KategorijaDodajRequest, KategorijaDodajResponse>
    {
        private readonly ApplicationDbContext _context;
        public KategorijaDodajEndpoint(ApplicationDbContext context){
            _context = context;
        }
        [HttpPost("dodaj")]

        public override async Task<KategorijaDodajResponse> Obradi(KategorijaDodajRequest request, CancellationToken cancellationToken)
        {
            eGym.Data.Models.Kategorija kategorija = new Models.Kategorija
            {
                NazivKategorije = request.NazivKategorije,
                Opis = request.Opis,
            };
            _context.Kategorija.Add(kategorija);
            await _context.SaveChangesAsync(cancellationToken);

            return new KategorijaDodajResponse { KategorijaId=kategorija.Id };
        }
    }
}
