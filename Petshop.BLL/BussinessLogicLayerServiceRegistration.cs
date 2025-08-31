using Microsoft.Extensions.DependencyInjection;
using Petshop.BLL.Mapping;
using Petshop.BLL.Services;
using Petshop.BLL.Services.Contracts;

namespace Petshop.BLL;

public static class BussinessLogicLayerServiceRegistration
{
    public static IServiceCollection AddBussinessLogicLayerServices(this IServiceCollection services)
    {
        services.AddAutoMapper(confg => confg.AddProfile<MappingProfile>());
        services.AddScoped(typeof(ICrudService<,,,>), typeof(CrudManager<,,,>));
        services.AddScoped<ICategoryService, CategoryManager>();
        services.AddScoped<IProductService, ProductManager>();
        services.AddScoped<IHomeService, HomeManager>();

        return services;
    }
}
