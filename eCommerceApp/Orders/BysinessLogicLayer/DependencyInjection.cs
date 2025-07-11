

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using eCommerce.OrdersMicroservice.BusinessLogicLayer.Validators;

namespace eCommerce.OrdersMicroservice.BusinessLogicLayer;

public static class DependencyInjection
{
    public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection serviceDescriptors, IConfiguration configuration)
    {
        //TO DO: Add data access layer services into the Ioc container

        serviceDescriptors.AddValidatorsFromAssemblyContaining<OrderAddRequestValidator>();

        return serviceDescriptors;
    }
}
