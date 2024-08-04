using eGym.Data.Endpoints.KategorijaEndpoints.GetAll;
using eGym.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eGym.Data.Endpoints.KategorijaEndpoints.GetById
{
    [Route("Kategorija")]
    [Tags("Kategorija")]
    public class KategorijaGetByIdEndpoint : MyBaseEndpoint<int, KategorijaGetResponse>
    {
        private readonly ApplicationDbContext _context;
        public KategorijaGetByIdEndpoint(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("Pretraga po Id")]
        public override async Task<KategorijaGetResponse> Obradi([FromQuery] int Id, CancellationToken cancellationToken)
        {
            var kategorije = await _context.Kategorija.Where(x => x.Id == Id)
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
