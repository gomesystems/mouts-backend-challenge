namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesRecord.CreateSales;

    public class CreateSalesResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;
}

