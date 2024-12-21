

using Ecommerce.Persistence.Abstracts;
using Ecommerce.Persistence.Concretes;
using Ecommerce.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Persistence;

public static class PersistenceDependenciesRegistraction
{

    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("SqlCon"));
        });
        services.AddScoped<ICategoryRepository,CategoryRepository>();
        
        return services;
    }


}
