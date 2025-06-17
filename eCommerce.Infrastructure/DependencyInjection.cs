using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace eCommerce.Infrastructure;

public static class DependencyInjection
{
    /// <summary>
    /// Extension method to add infrastrucure services to the dependecy injection container
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection
        AddInfrastructure(this IServiceCollection services)
    {
        //TO DO: Add services to the IoC container
        //Infrasture services often include data access, caching and othre low-level components.
        services.AddTransient<IUsersRepository, UsersRepository>();


        return services;
    }


}
