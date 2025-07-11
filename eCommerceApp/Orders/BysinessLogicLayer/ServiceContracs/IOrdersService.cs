
using eCommerce.OrdersMicroservice.BusinessLogicLayer.DTO;
using eCommerce.OrdersMicroservice.DataAccessLayer.Entities;
using MongoDB.Driver;

namespace eCommerce.OrdersMicroservice.BusinessLogicLayer.ServiceContracs;

public interface IOrdersService
{
    Task<List<OrderResponse?>> GetOrdersAsync();

    Task<List<OrderResponse?>> GetOrdersByConditionAsync(FilterDefinition<Order> filter);

    Task<OrderResponse?> GetOrderByConditionAsync(FilterDefinition<Order> filter);
    Task<OrderResponse?> AddOrderAsync(OrderAddRequest orderAddRequest);
    Task<OrderResponse?> UpdateOrderAsync(OrderUpdateRequest orderUpdateRequest);
    Task<bool> DeleteOrderAsync(Guid orderID);
}
