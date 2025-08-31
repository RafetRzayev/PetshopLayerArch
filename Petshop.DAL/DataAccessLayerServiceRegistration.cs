using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Petshop.DAL.DataContext;
using Petshop.DAL.Repositories;
using Petshop.DAL.Repositories.Contracts;

namespace Petshop.DAL;

public static class DataAccessLayerServiceRegistration
{
    public static IServiceCollection AddDataAccessLayerServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), options =>
            {
                options.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName); 
            }));
        
        services.AddScoped<DataInitializer>();

        services.AddScoped(typeof(IRepository<>), typeof(EfCoreRepository<>));
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();

        return services;
    }
}
