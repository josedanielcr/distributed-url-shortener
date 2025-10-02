using Api.Common;
using Api.Contracts.Requests;
using Application.ShortUrls.CreateShortUrl;
using Carter;
using Microsoft.Extensions.Options;

namespace Api.Features.CreateShortUrl;

public class CreateShortUrlModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("", async (ICreateShortUrlService createShortUrlService, 
            IOptions<Settings> settings,
            CreateShortUrlReq createShortUrlReq) =>
        {
            var createShortUrlInput = new CreateShortUrlInput
            {
                OriginalUrl = createShortUrlReq.OriginalUrl,
                HostMachine = settings.Value.HostMachine
            };
            var result = await createShortUrlService.CreateShortUrl(createShortUrlInput);
            return Results.Ok(result);
        });
    }
}