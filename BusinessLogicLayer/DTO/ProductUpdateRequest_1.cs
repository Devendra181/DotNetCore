
using eCommerce.BusinessLogicLayer.DTO;

namespace BusinessLogicLayer.DTO;

public record ProductUpdateRequest
(
    string ProductName,
    CategoryOptions Category,
    double? UnitPrice,
    int? QuantityInStock
)
{
    public ProductUpdateRequest(): this(default, default, default, default)
    {
    }
}