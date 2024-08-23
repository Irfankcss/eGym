using eGym.Data;
using eGym.Data.Models;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

namespace eGym.Data.Helpers.Services
{
    public class MyAuthService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MyAuthService(ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _applicationDbContext = applicationDbContext;
            _httpContextAccessor = httpContextAccessor;
        }
        public bool isAdmin()
        {
            return GetKorisnik().korisnickiNalog?.isAdmin ?? false;
        }
        public bool isRadnik()
        {
            return GetKorisnik().korisnickiNalog?.isRadnik ?? false;
        }
        public bool isLogiran()
        {
            return GetKorisnik()?.isLogiran ?? false;
        }
        public MyAuthInfo GetKorisnik()
        {
            var autentifikacijaKorisnik = _applicationDbContext.AutentifikacijaToken.Include(x => x.korisnickiNalog).FirstOrDefault();
            return new MyAuthInfo(autentifikacijaKorisnik);
        }

        public MyAuthInfo GetAuthInfo()
        {
            string? authToken = _httpContextAccessor.HttpContext!.Request.Headers["my-auth-token"];

            AutentifikacijaToken? autentifikacijaToken = _applicationDbContext.AutentifikacijaToken
                .Include(x => x.korisnickiNalog)
                .SingleOrDefault(x => x.vrijednost == authToken);

            return new MyAuthInfo(autentifikacijaToken);
        }
    }

    public class MyAuthInfo
    {
        public MyAuthInfo(AutentifikacijaToken? autentifikacijaToken)
        {
            this.autentifikacijaToken = autentifikacijaToken;
        }

        [JsonIgnore]
        public KorisnickiNalog? korisnickiNalog => autentifikacijaToken?.korisnickiNalog;
        public AutentifikacijaToken? autentifikacijaToken { get; set; }

        public bool isLogiran => korisnickiNalog != null;

    }
}