namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesRecord.CreateSales;

    public class SalesRecordsResponse
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime SaleDate { get; set; } = DateTime.UtcNow;

}

