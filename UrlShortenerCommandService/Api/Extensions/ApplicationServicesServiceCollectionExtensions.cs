using Application.ShortUrls.CreateShortUrl;
using Domain.Repository;
using Persistance.Repositories;

namespace Api.Extensions;

public static class ApplicationServicesServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);
        services.AddScoped<IShortUrlRepository, ShortUrlRepository>();
        services.AddScoped<ICreateShortUrlService, CreateShortUrlService>();
        return services;
    }
}