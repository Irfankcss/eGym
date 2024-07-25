using eGym.Data.Helpers.Services;
using eGym.Data.Helpers;
using eGym.Data.Models;
using eGym.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace eGym.Data.Endpoints.AuthEndpoints.Logout
{
    [Tags("Auth")]
    public class AuthLogoutEndpoint : MyBaseEndpoint<NoRequest, NoResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly MyAuthService _authService;

        public AuthLogoutEndpoint(ApplicationDbContext applicationDbContext, MyAuthService authService)
        {
            _applicationDbContext = applicationDbContext;
            _authService = authService;
        }

        [HttpPost("logout")]
        public override async Task<NoResponse> Obradi([FromBody] NoRequest request, CancellationToken cancellationToken)
        {
            AutentifikacijaToken? autentifikacijaToken = _authService.GetAuthInfo().autentifikacijaToken;

            if (autentifikacijaToken == null)
                return new NoResponse();

            _applicationDbContext.Remove(autentifikacijaToken);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return new NoResponse();
        }


    }
}
