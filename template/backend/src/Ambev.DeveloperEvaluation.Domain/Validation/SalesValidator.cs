using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{

    /*
    ### Business Rules 
    
     * Purchases above 4 identical items have a 10% discount 
     * * Purchases between 10 and 20 identical items have a 20% discount 
     * * It's not possible to sell above 20 identical items 
     * * Purchases below 4 items cannot have a discount These business rules define quantity-based discounting tiers and 
     * limitations: 1. Discount Tiers: - 4+ items: 10% discount - 10-20 items: 20% discount 2. Restrictions: - Maximum limit: 20 items per product - No discounts allowed for quantities below 4 items
     
     */

    public class SalesValidator : FluentValidation.AbstractValidator<Entities.SalesRecords>
    {
        public SalesValidator() { 
            RuleFor(sale => sale.SaleNumber)
                .NotEmpty().WithMessage("Sale number is required.")
                .MaximumLength(20).WithMessage("Sale number cannot exceed 20 characters.");

            RuleFor(sale => sale.Items).NotEmpty().WithMessage("Sale must contain at least one item.");
            RuleForEach(sale => sale.Items).ChildRules(items =>
            {
                items.RuleFor(item => item.Quantity)
                    .GreaterThan(0).WithMessage("Item quantity must be greater than zero.")
                    .LessThanOrEqualTo(20).WithMessage("Cannot sell more than 20 identical items.");
                items.RuleFor(item => item.UnitPrice)
                    .GreaterThan(0).WithMessage("Item unit price must be greater than zero.");
                items.RuleFor(item => item.Discount)
                    .GreaterThanOrEqualTo(0).WithMessage("Item discount cannot be negative.")
                    .Must((item, discount) =>
                    {
                        if (item.Quantity < 4 && discount > 0)
                            return false; // No discount allowed for less than 4 items
                        if (item.Quantity >= 4 && item.Quantity < 10 && discount > item.UnitPrice * item.Quantity * 0.10m)
                            return false; // Max 10% discount for 4-9 items
                        if (item.Quantity >= 10 && item.Quantity <= 20 && discount > item.UnitPrice * item.Quantity * 0.20m)
                            return false; // Max 20% discount for 10-20 items
                        return true;
                    }).WithMessage("Invalid discount based on item quantity.");
            });
          
        }

    }
}
