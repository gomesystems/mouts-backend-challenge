namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesRecord.GetSales;

    public class GetSalesRecordsResponse
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime SaleDate { get; set; } = DateTime.UtcNow;

}

