using Microsoft.EntityFrameworkCore;
using WooingApi.Data;

namespace WooingApi.Extensions;

public static class ApplicationServiceExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        //Add DBContext
        
        services.AddDbContext<DataContext>(options=>options.UseSqlite());

        return services;
    }
}