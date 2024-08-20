using eGym.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static eGym.Data.Endpoints.RadnikEndpoints.GetByID.RadnikGetByResponse;

namespace eGym.Data.Endpoints.RadnikEndpoints.GetByID
{
    [Tags("Radnik")]
    public class RadnikGetByEndpoint : MyBaseEndpoint<RadnikGetByRequest, RadnikGetByResponse>
    {
        private readonly ApplicationDbContext _context;
        public RadnikGetByEndpoint(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("GetByID")]
        public override async Task<RadnikGetByResponse> Obradi([FromQuery]RadnikGetByRequest request, CancellationToken cancellationToken)
        {
            var radnici = _context.Radnik.Where(r=>request.ID == r.ID).FirstOrDefault();
            if(radnici == null || radnici.isRadnik == false){
                throw new Exception("Radnik nije pronađen");
            }
            var radniciIspis = await _context.Radnik.Where(r => request.ID == r.ID).Select(x => new RadnikGetBy()
            {
                Ime = x.Ime,
                Prezime = x.Prezime,
                DatumZaposlenja = DateOnly.FromDateTime(x.DatumZaposlenja),
                Spol = x.Spol
            }).ToListAsync();
            return new RadnikGetByResponse
            {
                radnici = radniciIspis
            };
        }
    }
}
