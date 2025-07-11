
using eCommerce.OrdersMicroservice.DataAccessLayer.Entities;
using MongoDB.Driver;

namespace  eCommerce.OrdersMicroservice.DataAccessLayer.RepositoryContracts;

public interface IOrdersRepository
{
    Task<IEnumerable<Order?>> GetOrdersAsync();

    Task<IEnumerable<Order?>> GetOrdersByConditionAsync(FilterDefinition<Order> filter);

    Task<Order?> GetOrderByConditionAsync(FilterDefinition<Order> filter);

    Task<Order?> AddOrder(Order order);

    Task<Order?> UpdateOrder(Order order);

    Task<bool> DeleteOrder(Guid orderID);
}
