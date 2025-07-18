﻿
namespace eCommerce.OrdersMicroservice.BusinessLogicLayer.DTO;

public record OrderItemResponse
    (
    Guid ProductID,
    decimal UinitPrice,
    int Quantity,
    decimal TotalPrice
    )
{
    public OrderItemResponse() : this(default, default, default, default)
    {
    }
}