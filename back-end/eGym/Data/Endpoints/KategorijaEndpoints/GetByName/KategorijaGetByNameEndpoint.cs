using eGym.Data.Endpoints.KategorijaEndpoints.GetAll;
using eGym.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eGym.Data.Endpoints.KategorijaEndpoints.GetById
{
    [Route("Kategorija")]
    [Tags("Kategorija")]
    public class KategorijaGetByNameEndpoint : MyBaseEndpoint<KategorijaGetByNameRequest,KategorijaGetResponse>
    {
        private readonly ApplicationDbContext _context;
        public KategorijaGetByNameEndpoint(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("Pretraga po nazivu")]
        public override async Task<KategorijaGetResponse> Obradi([FromQuery] KategorijaGetByNameRequest request, CancellationToken cancellationToken)
        {
            var kategorije = await _context.Kategorija.Where(x=> request.KategorijaNaziv == null || x.NazivKategorije.ToLower() == request.KategorijaNaziv.ToLower())
                .Select(x => new KategorijaGetResponseKategorija
            {
                KategorijaId = x.Id,
                Naziv = x.NazivKategorije,
                Opis = x.Opis,
            }).ToListAsync(cancellationToken);

            return new KategorijaGetResponse
            {
                Kategorije = kategorije,
            };


        }
    }
}
