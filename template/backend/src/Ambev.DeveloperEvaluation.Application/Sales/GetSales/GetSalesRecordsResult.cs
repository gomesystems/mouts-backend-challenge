namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales
{
    public class GetSalesRecordsResult
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
