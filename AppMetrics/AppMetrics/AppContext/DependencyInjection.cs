using AppMetrics.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppMetrics.AppContext;

public static class DependenciesInjection
{
    public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));

            options.EnableDetailedErrors();
            options.EnableSensitiveDataLogging();
        });

        services.AddScoped<IAppDbContext>(provider => provider.GetService<AppDbContext>());

        return services;
    }
}