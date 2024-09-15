using Azure.Core;
using eGym.Data.Models;
using eGym.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eGym.Data.Endpoints.Admin.Dodaj
{
    [Tags("Admin")]
    public class AdminDodajEndpoint : MyBaseEndpoint<AdminDodajRequest, AdminDodajResponse>
    {
        public readonly ApplicationDbContext _applicationDbContext;
        public AdminDodajEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpPost]
        public override async Task<AdminDodajResponse> Obradi(AdminDodajRequest request, CancellationToken cancellationToken)
        {
            var noviObj = new Models.Admin
            {
                ID = request.AdminID,
                AdminKod = request.AdminKod,
                Email = request.Email,
                Slika = request.Slika,
                KorisnickoIme = request.KorisnickoIme,
                Lozinka = request.Lozinka,
                isRadnik = false,
                isAdmin = true,
                isKorisnik = false
            };
            _applicationDbContext.Add(noviObj);
            await _applicationDbContext.SaveChangesAsync();


            return new AdminDodajResponse
            {
                AdminID = noviObj.ID
            };
        }
    }
}
