
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
        // Add AutoMapper configuration using the correct overload
        services.AddAutoMapper(cfg => cfg.AddMaps(typeof(ProductToProductResponseMappingProfile).Assembly));

        services.AddValidatorsFromAssemblyContaining<ProductAddRequestValidator>();

        services.AddScoped<IProductService, eCommerce.BusinessLogicLayer.Services.ProductsService>();

        return services;
    }
}
