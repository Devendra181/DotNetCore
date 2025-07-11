
namespace eCommerce.OrdersMicroservice.BusinessLogicLayer.DTO;

public record OrderItemUpdateRequest
    (
    Guid ProductID,
    decimal UinitPrice,
    int Quantity
    )
{
    public OrderItemUpdateRequest() : this(default, default, default)
    {
    }
}