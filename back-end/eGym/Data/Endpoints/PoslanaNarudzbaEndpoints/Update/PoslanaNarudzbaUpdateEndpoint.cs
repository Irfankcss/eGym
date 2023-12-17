using eGym.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eGym.Data.Endpoints.PoslanaNarudzbaEndpoints.Update
{
    [Route("PoslanaNarudzba")]
    [Tags("Poslana Narudzba")]
    public class PoslanaNarudzbaUpdateEndpoint : MyBaseEndpoint<PoslanaNarudzbaUpdateRequest, string>
    {
        private readonly ApplicationDbContext _context;
        public PoslanaNarudzbaUpdateEndpoint(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPut("PoslanaNarudzba Update")]
        public override async Task<string> Obradi(PoslanaNarudzbaUpdateRequest request, CancellationToken cancellationToken)
        {
            var poslananarudzba = await _context.PoslanaNarudzba.FirstOrDefaultAsync(x => x.PoslanaNarudzbaID == request.PoslanaNarudzbaID);
            if (poslananarudzba == null)
                return "poslananarudzba ne postoji";
            poslananarudzba.isPreuzeta = request.isPreuzeta ?? poslananarudzba.isPreuzeta;
            poslananarudzba.isIsporucena = request.isIsporucena ?? poslananarudzba.isIsporucena;
            poslananarudzba.DatumPreuzimanja = request.DatumPreuzimanja ?? poslananarudzba.DatumPreuzimanja;
            poslananarudzba.DatumIsporuke=request.DatumIsporuke ?? poslananarudzba. DatumIsporuke;
            _context.PoslanaNarudzba.Update(poslananarudzba);
            await _context.SaveChangesAsync(cancellationToken);
            return "Uspjesno izvrsena promjena na poslanoj narudzbi";
        }
    }
}
