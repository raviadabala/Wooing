using Microsoft.EntityFrameworkCore;
using WooingApi.Data;

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

        return services;
    }
}