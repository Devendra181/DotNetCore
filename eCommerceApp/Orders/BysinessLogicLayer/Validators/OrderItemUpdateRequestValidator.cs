
using eCommerce.OrdersMicroservice.BusinessLogicLayer.DTO;
using FluentValidation;

namespace eCommerce.OrdersMicroservice.BusinessLogicLayer.Validators;

public class OrderItemUpdateRequestValidator : AbstractValidator<OrderItemUpdateRequest>
{
    public OrderItemUpdateRequestValidator()
    {
        RuleFor(temp => temp.ProductID)
        .NotEmpty().WithErrorCode("ProductID can't be blank");

        RuleFor(temp => temp.UinitPrice)
       .NotEmpty().WithErrorCode("UinitPrice be blank")
       .GreaterThan(0).WithErrorCode("UinitPrice can't be less than zero");

        RuleFor(temp => temp.Quantity)
       .NotEmpty().WithErrorCode("Quantity can't be blank")
       .GreaterThan(0).WithErrorCode("Quantity can't be less than zero"); ;
    }
}
