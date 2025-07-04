using BusinessLogicLayer.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.BusinessLogicLayer.Validators;

public class ProductUpdateRequestValidator: AbstractValidator<ProductUpdateRequest>
{
    public ProductUpdateRequestValidator()
    {
        //ProductName
        RuleFor(temp => temp.productId)
            .NotEmpty().WithMessage("Product Id  can't be blank");

        //ProductName
        RuleFor(temp => temp.ProductName)
            .NotEmpty().WithMessage("Product Name can't be blank");

        //Category
        RuleFor(temp => temp.Category)
            .IsInEnum().WithMessage("Given category does not exists");

        //UnitPrice
        RuleFor(temp => temp.UnitPrice)
            .InclusiveBetween(0, double.MaxValue).WithMessage($"Unit Price shuld be between 0 to {double.MaxValue}");

        //QunatiryInStock
        RuleFor(temp => temp.QuantityInStock)
            .InclusiveBetween(0, int.MaxValue).WithMessage($"Qunatiry in stock shuld be between 0 to {double.MaxValue}");

    }
}
