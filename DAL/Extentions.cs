using System;
using Microsoft.EntityFrameworkCore;
namespace ApiDogs.DAL;

public static class Extentions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DogsContext>(options =>
        {
            var connectionString = configuration["ConnectionString"];
            options.UseNpgsql(connectionString);
        });

        services.AddHostedService<DatabaseInitializer<DogsContext>>();

        return services;
    }
}