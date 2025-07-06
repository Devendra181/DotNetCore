using eCommerce.BusinessLogicLayer.DTO;
using FluentValidation;


namespace eCommerce.BusinessLogicLayer.Validators;

public class ProductAddRequestValidator: AbstractValidator<ProductAddRequest>
{
    public ProductAddRequestValidator()
    {
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
