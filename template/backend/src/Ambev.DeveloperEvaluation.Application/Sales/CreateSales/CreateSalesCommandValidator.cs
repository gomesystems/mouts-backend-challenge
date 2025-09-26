using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSales;

public class CreateSalesCommandValidator : FluentValidation.AbstractValidator<CreateSalesCommand>
{
    public CreateSalesCommandValidator() {
        RuleFor(sale => sale.ProductId).NotEmpty().WithMessage("ProductId is required.");
        RuleFor(sale => sale.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than zero.");
        RuleFor(sale => sale.Price).GreaterThan(0).WithMessage("Price must be greater than zero.");
        RuleFor(sale => sale.SaleDate).LessThanOrEqualTo(DateTime.UtcNow).WithMessage("SaleDate cannot be in the future.");

    }
}