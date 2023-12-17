using eGym.Helper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eGym.Data.Endpoints.RadnikEndpoints.GetAll
{
    [Microsoft.AspNetCore.Mvc.Route("Radnik")]
    [Tags("Radnik")]
    public class RadnikGetAllEndpoint : MyBaseEndpoint<RadnikGetAllRequest,RadnikGetAllResponse>
    {
        private readonly ApplicationDbContext _context;

        public RadnikGetAllEndpoint(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public override async Task<RadnikGetAllResponse> Obradi([FromQuery] RadnikGetAllRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var radnici = await _context.Radnik.Select(x => new RadnikGetAllResponseRadnik
                {
                    Id = x.ID,
                    Ime = x.Ime,
                    Prezime = x.Prezime,
                    BrojTelefona = x.BrojTelefona,
                    DatumRodjenja = x.DatumRodjenja,
                    DatumZaposlenja = x.DatumZaposlenja,
                    Spol = x.Spol,
                    GradID = x.GradID,
                    grad = x.grad,
                    KorisnickoIme = x.KorisnickoIme,
                    Slika = x.Slika,
                    Email = x.Email
                }).ToListAsync(cancellationToken);
                
                    return new RadnikGetAllResponse
                    {Radnici = radnici};
                
            }catch (Exception ex)
            {
                Console.WriteLine("ERROR----->" + ex.ToString());
                throw ex;
            }
        }
    }
}
