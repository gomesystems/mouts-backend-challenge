using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesRecord.GetSales;

public class GetSalesRecordsRequestValidator : AbstractValidator<GetSalesRecordsRequest>
{
    public GetSalesRecordsRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Sales record ID is required");
    }
}
