using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesRecord.CreateSales;

    public class CreateSalesRequestValidator : AbstractValidator<CreateSalesRequest>
    {
        public CreateSalesRequestValidator()
        {
            RuleFor(sales => sales.UserId).NotEmpty();
            RuleFor(sales => sales.Amount).GreaterThan(0);
            RuleFor(sales => sales.Date).LessThanOrEqualTo(DateTime.UtcNow);
            RuleFor(sales => sales.Description).MaximumLength(250);
        }

    }

