using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesRecord.DeleteSales;

public class DeleteSalesRequestValidator : AbstractValidator<DeleteSalesRequest>
{
    public DeleteSalesRequestValidator() {
        RuleFor(x => x.Id)
          .NotEmpty()
          .WithMessage("User ID is required");
    }
}
