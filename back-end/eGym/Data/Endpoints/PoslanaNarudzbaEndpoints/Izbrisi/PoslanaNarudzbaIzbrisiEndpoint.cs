using eGym.Data.Helpers.Services;
using eGym.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eGym.Data.Endpoints.PoslanaNarudzbaEndpoints.Izbrisi
{
    [Route("PoslanaNarudzba")]
    [Tags("Poslana Narudzba")]
    public class PoslanaNarudzbaIzbrisiEndpoint : MyBaseEndpoint<int,string>
    {
        private readonly ApplicationDbContext _context;
        public readonly MyAuthService _authService;
        public PoslanaNarudzbaIzbrisiEndpoint(ApplicationDbContext context, MyAuthService authService)
        {
            _context = context;
            _authService = authService;
        }
        [HttpDelete("PoslanaNarudzba izbrisi")]
        public override async Task<string> Obradi(int request, CancellationToken cancellationToken)
        {
            if (!(_authService.isAdmin() && _authService.isLogiran()))
                throw new Exception("Korisnik nema permisiju Admina ili nije logiran");

            var poslananarudzba= await _context.PoslanaNarudzba.FirstAsync(x=>x.PoslanaNarudzbaID==request);
            if (poslananarudzba == null)
            {
                return "PoslanaNarudzba ne postoji";
            }
            _context.PoslanaNarudzba.Remove(poslananarudzba);
            await _context.SaveChangesAsync();
            return "PoslanaNarudzba izbrisana";
        }
    }
}
