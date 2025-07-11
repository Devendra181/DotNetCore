

using eCommerce.OrdersMicroservice.DataAccessLayer.Repositories;
using eCommerce.OrdersMicroservice.DataAccessLayer.RepositoryContracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace eCommerce.OrdersMicroservice.DataAccessLayer;

public static class DependencyInjection
{
    public static IServiceCollection AddDatabaseAccesLayer(this IServiceCollection serviceDescriptors, IConfiguration configuration)
    {
        //TO DO: Add data access layer services into the Ioc container

        string connectionStringTemplate = configuration.GetConnectionString("MongoDB")!;
        string connectionString = connectionStringTemplate.Replace("$MONGODB_HOST", Environment.GetEnvironmentVariable("MONGODB_HOST"))
            .Replace("$MONGODB_PORT", Environment.GetEnvironmentVariable("MONGODB_PORT"));

        serviceDescriptors.AddSingleton<IMongoClient>(new MongoClient(connectionString));

        serviceDescriptors.AddScoped<IMongoDatabase>(provider =>
        {
           IMongoClient client = provider.GetRequiredService<IMongoClient>();
           return client.GetDatabase("OrdersDatabase"); 
        });

        serviceDescriptors.AddScoped<IOrdersRepository, OrdersRepository>();

        return serviceDescriptors;
    }
}
