﻿
using eCommerce.OrdersMicroservice.BusinessLogicLayer.DTO;
using FluentValidation;

namespace eCommerce.OrdersMicroservice.BusinessLogicLayer.Validators;

public class OrderAddRequestValidator: AbstractValidator<OrderAddRequest>
{
    public OrderAddRequestValidator()
    {
        RuleFor(temp => temp.UserID)
        .NotEmpty().WithErrorCode("User ID can't be blank");

        RuleFor(temp => temp.OrderDate)
       .NotEmpty().WithErrorCode("OrderDate can't be blank");

        RuleFor(temp => temp.OrderItems)
       .NotEmpty().WithErrorCode("OrderItems can't be blank");
    }
}
