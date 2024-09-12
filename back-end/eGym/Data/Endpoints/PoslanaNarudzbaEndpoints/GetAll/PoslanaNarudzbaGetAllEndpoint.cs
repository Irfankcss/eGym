using eGym.Data.Helpers.Services;
using eGym.Data.Models;
using eGym.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;

namespace eGym.Data.Endpoints.PoslanaNarudzbaEndpoints.GetAll
{
    [Route("PoslanaNarudzba")]
    [Tags("Poslana Narudzba")]
    public class PoslanaNarudzbaGetAllEndpoint : MyBaseEndpoint<int?, List<PoslanaNarudzbaGetAllResponse>>
    {
        private readonly ApplicationDbContext _context;
        public readonly MyAuthService _authService;
        public PoslanaNarudzbaGetAllEndpoint(ApplicationDbContext context, MyAuthService authService)
        {
            _context = context;
            _authService = authService;
        }



        [HttpGet("PoslanaNarudzba Get by NarudzbaID")]
        public override async Task<List<PoslanaNarudzbaGetAllResponse>> Obradi(int? NarudzbaID, CancellationToken cancellationToken)
        {
            if (!(_authService.isRadnik() || (_authService.isAdmin() && _authService.isLogiran())))
                throw new Exception("Korisnik nema permisiju Radnika ili nije logiran");

            var pn = await _context.PoslanaNarudzba.Include(p=>p.Radnik).ThenInclude(r=>r.grad).ThenInclude(g=>g.Drzava).Where(x => NarudzbaID == null || x.NarudzbaID == NarudzbaID).Select(x=> new PoslanaNarudzbaGetAllResponse
            {
                PoslanaNarudzbaID = x.PoslanaNarudzbaID,
                DatumIsporuke =x.DatumIsporuke,
                DatumSlanja =x.DatumSlanja,
                DatumPreuzimanja =x.DatumPreuzimanja,
                isIsporucena=x.isIsporucena,
                isPreuzeta=x.isPreuzeta,
                Radnik= x.Radnik
                ,NarudzbaID=x.NarudzbaID

            }).ToListAsync(cancellationToken: cancellationToken);

            return  pn;
        }
    }
}
