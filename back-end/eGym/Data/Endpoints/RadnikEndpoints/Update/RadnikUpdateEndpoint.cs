using eGym.Data.Models;
using eGym.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace eGym.Data.Endpoints.RadnikEndpoints.Update
{
    [Route("Radnik")]
    [Tags("Radnik")]
    public class RadnikUpdateEndpoint : MyBaseEndpoint <RadnikUpdateRequest,RadnikUpdateResponse>
    {
        private readonly ApplicationDbContext _context;

        public RadnikUpdateEndpoint(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPut("Radnik update")]
        public override async Task<RadnikUpdateResponse> Obradi([FromQuery]RadnikUpdateRequest request, CancellationToken cancellationToken)
        {
            var temp = await _context.Radnik.FirstOrDefaultAsync(x=>x.ID == request.RadnikID);
            if (temp == null)
            {
                throw new Exception("Nije pronadjen radnik sa tim ID-jem");
            }
            temp.Ime = request.Ime ?? temp.Ime;
            temp.Prezime = request.Prezime ?? temp.Prezime;
            temp.Slika = request.Slika ?? temp.Slika;
            temp.DatumRodjenja = request.DatumRodjenja ?? temp.DatumRodjenja;
            temp.DatumZaposlenja=request.DatumZaposlenja?? temp.DatumZaposlenja;
            temp.GradID = request.GradID ?? temp.GradID;
            temp.grad = request.grad ?? temp.grad;
            temp.BrojTelefona=request.BrojTelefona ?? temp.BrojTelefona;
            temp.Email = request.Email ?? temp.Email;
            temp.Spol=request.Spol ?? temp.Spol;

            await _context.SaveChangesAsync(cancellationToken);
            return new RadnikUpdateResponse
            {
                RadnikID = temp.ID,
                BrojTelefona = temp.BrojTelefona,
                DatumRodjenja = temp.DatumRodjenja,
                grad = temp.grad,
                Ime = temp.Ime,
                Prezime = temp.Prezime
            };
        }
    }
}
