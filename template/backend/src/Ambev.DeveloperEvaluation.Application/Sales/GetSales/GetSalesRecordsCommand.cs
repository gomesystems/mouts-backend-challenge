namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales;

public class GetSalesRecordsCommand : MediatR.IRequest<GetSalesRecordsResult>
{
    public Guid UserId { get; }
    public GetSalesRecordsCommand(Guid userId)
    {
        UserId = userId;
    }
}
