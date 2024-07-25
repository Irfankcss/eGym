using Microsoft.AspNetCore.Mvc;

namespace eGym.Helpers;

[ApiController]
[Route("[Action]/[Controller]")]
public abstract class MyBaseEndpoint<TRequest, TResponse> : ControllerBase
{
    public abstract Task<TResponse> Obradi(TRequest request, CancellationToken cancellationToken);
}