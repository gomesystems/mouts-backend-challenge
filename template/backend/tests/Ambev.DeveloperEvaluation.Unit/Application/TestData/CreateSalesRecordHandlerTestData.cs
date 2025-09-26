using Ambev.DeveloperEvaluation.Application.Sales.CreateSales;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain;


public static class CreateSalesRecordHandlerTestData
{

    
       private static readonly Faker<CreateSalesCommand> createSalesHandlerFaker = new Faker<CreateSalesCommand>()
        .RuleFor(s => s.ProductId, f => f.Random.Guid())
        .RuleFor(s => s.Quantity, f => f.Random.Int(1, 100))
        .RuleFor(s => s.Price, f => Math.Round(f.Random.Decimal(1, 1000), 2))
        .RuleFor(s => s.SaleDate, f => f.Date.Past(1));
    

    public static CreateSalesCommand GenerateValidCommand()
    {
        return createSalesHandlerFaker.Generate();
    }
}
