using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistance.Database;

namespace Api.Extensions;

public static class ApplicationDbServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationDb(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configuration);
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("ConnectionStrings:Default")
                 , opt => opt.SetPostgresVersion(configuration.GetValue<int>("EfCorePostgres:Version"),0));
        });
        return services;
    }
}