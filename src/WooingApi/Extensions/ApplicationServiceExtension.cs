using Microsoft.EntityFrameworkCore;
using WooingApi.Data;
using WooingApi.Interfaces;
using WooingApi.Services;

namespace WooingApi.Extensions;

public static class ApplicationServiceExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        //Add DBContext
        var connectionString = config.GetConnectionString("WooingSqliteDB");
        services.AddDbContext<DataContext>(options=>options.UseSqlite(connectionString));
        //Automapper
        services.AddAutoMapper(typeof(Profiles.WooingProfiles));
        //Services
        services.AddScoped<ITokenService,TokenService>();

        return services;
    }
}