namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    
    public class SaleItem
    {
      
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalItemAmount { get; set; }
        public decimal TotalPrice { get; internal set; }
    }
}