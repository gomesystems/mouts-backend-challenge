using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSales;

public class DeleteSalesCommand : IRequest<DeleteSalesResponse>
{
    public Guid Id { get; }


    public DeleteSalesCommand() { 
        Id = Guid.NewGuid();
     }
}
