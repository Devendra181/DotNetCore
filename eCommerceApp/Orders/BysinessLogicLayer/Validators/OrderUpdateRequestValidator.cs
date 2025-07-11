
using eCommerce.OrdersMicroservice.BusinessLogicLayer.DTO;
using FluentValidation;

namespace eCommerce.OrdersMicroservice.BusinessLogicLayer.Validators;

public class OrderUpdateRequestValidator : AbstractValidator<OrderUpdateRequest>
{
    public OrderUpdateRequestValidator()
    {
        RuleFor(temp => temp.OrderID)
       .NotEmpty().WithErrorCode("OrderID can't be blank");

        RuleFor(temp => temp.UserID)
        .NotEmpty().WithErrorCode("User ID can't be blank");

        RuleFor(temp => temp.OrderDate)
       .NotEmpty().WithErrorCode("OrderDate can't be blank");

        RuleFor(temp => temp.OrderItems)
       .NotEmpty().WithErrorCode("OrderItems can't be blank");
    }
}
