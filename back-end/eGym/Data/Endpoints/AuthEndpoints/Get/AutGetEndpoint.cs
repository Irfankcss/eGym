using eGym.Data.Helpers.Services;
using eGym.Data.Helpers;
using eGym.Helpers;
using eGym.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eGym.Data.Endpoints.AuthEndpoints.Get
{
    [Tags("Auth")]
    public class AutGetEndpoint : MyBaseEndpoint<NoRequest, MyAuthInfo>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly MyAuthService _authService;
        public AutGetEndpoint(ApplicationDbContext applicationDbContext, MyAuthService authService)
        {
            _applicationDbContext = applicationDbContext;
            _authService = authService;
        }
        [HttpPost("get")]
        public override async Task<MyAuthInfo> Obradi([FromQuery] NoRequest request, CancellationToken cancellationToken)
        {
            AutentifikacijaToken? autentifikacijaToken = _applicationDbContext.AutentifikacijaToken.Include(k=> k.korisnickiNalog).FirstOrDefault();

            return new MyAuthInfo(autentifikacijaToken);
        }
    }
}
