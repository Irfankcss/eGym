using eGym.Helpers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eGym.Data.Endpoints.RadnikEndpoints.GetById
{
    [Microsoft.AspNetCore.Mvc.Route("Radnik")]
    [Tags("Radnik")]
    public class RadnikGetByIdEndpoint : MyBaseEndpoint<int,RadnikGetByIdResponse>
    {
        private readonly ApplicationDbContext _context;
        public RadnikGetByIdEndpoint(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("Get by Id")]
        public override async Task<RadnikGetByIdResponse> Obradi(int request, CancellationToken cancellationToken)
        {
            var radnik = await _context.Radnik
           .OrderByDescending(x => x.ID)
           .Select(x => new RadnikGetByIdResponse
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

           }).SingleAsync(x => x.Id == request, cancellationToken: cancellationToken);

            return radnik;
        }
    }
}
