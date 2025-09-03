using Persistance.Database;

namespace Api.Extensions;

public static class ApplicationDbServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationDb(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configuration);
        services.AddDbContext<ApplicationDbContext>();
        return services;
    }
}