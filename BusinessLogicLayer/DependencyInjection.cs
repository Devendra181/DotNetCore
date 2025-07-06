
using eCommerce.BusinessLogicLayer.Mapper;
using Microsoft.Extensions.DependencyInjection;
using eCommerce.BusinessLogicLayer.ServiceContracts;
using FluentValidation;
using eCommerce.BusinessLogicLayer.Validators;


namespace eCommerce.ProductsService.BusinessLogicLayer;

public static class DependencyInjection
{
    public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services)
    {
        //TO DO: Add Business Logic Layer services into the IoC container

        services.AddAutoMapper(typeof(ProductToProductResponseMappingProfile).Assembly);

        services.AddValidatorsFromAssemblyContaining<ProductAddRequestValidator>();

        services.AddScoped<IProductService, eCommerce.BusinessLogicLayer.Services.ProductsService>();

        return services;
    }
}
