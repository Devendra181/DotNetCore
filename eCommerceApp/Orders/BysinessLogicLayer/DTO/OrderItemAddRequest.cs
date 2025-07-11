
namespace eCommerce.OrdersMicroservice.BusinessLogicLayer.DTO;

public record OrderItemAddRequest
    (
    Guid ProductID, 
    decimal UinitPrice, 
    int Quantity
    )
{
    public OrderItemAddRequest():this(default, default, default)
    {
    }
}
