
using DataAccessLayer.Repositories;
using eCommerce.DataAccessLayer.Context;
using eCommerce.DataAccessLayer.RepositoryContracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.ProductsService.DataAccessLayer;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
    {
        //TO DO: Add Data Access Layer services into the IoC container

        services.AddDbContext<ApplicationDBContext>(options => {
            options.UseMySQL(configuration.GetConnectionString("DefaultConnection")!);
        });

        services.AddScoped<IProductsRepository, ProductsRepository>();


        return services;
    }
}
