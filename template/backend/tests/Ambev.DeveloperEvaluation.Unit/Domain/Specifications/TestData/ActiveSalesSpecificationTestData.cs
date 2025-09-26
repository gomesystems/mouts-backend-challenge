using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Specifications.TestData;

public static class ActiveSalesSpecificationTestData
{
  
    private static readonly Faker<SalesRecords> userFaker = new Faker<SalesRecords>()
        .CustomInstantiator(f => new SalesRecords
        {
            SaleNumber = f.Commerce.Ean13(),
            SaleDate = f.Date.Past(),
            Customer = f.Name.FullName(),
            TotalSaleAmount = f.Finance.Amount(10, 1000),
            Branch = f.Company.CompanyName(),
            Quantity = f.Random.Number(1, 20),
            UnitPrice = f.Finance.Amount(5, 500),
            Discount = 0,
            TotalItemAmount = 0
        });


    public static User GenerateSales()
    {
        var user = userFaker.Generate();
        return null;
    }
}
