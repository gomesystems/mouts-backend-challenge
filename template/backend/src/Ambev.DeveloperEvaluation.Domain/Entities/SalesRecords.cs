using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{

    /*
     Regras de Negócio

        Compras acima de 4 itens idênticos têm 10% de desconto
        Compras entre 10 e 20 itens idênticos têm 20% de desconto
        Não é possível vender mais de 20 itens idênticos
        Compras abaixo de 4 itens não podem ter desconto
        Essas regras de negócio definem faixas de desconto baseadas na quantidade e suas limitações:

        Faixas de Desconto:

        4+ itens: 10% de desconto
        10 a 20 itens: 20% de desconto
        Restrições:

        Limite máximo: 20 itens por produto
        Nenhum desconto permitido para quantidades abaixo de 4 itens
     
     */
    public class SalesRecords : BaseEntity, ISalesRecords
    {


        //Sale number 
        public string SaleNumber { get; set; }

        //Date when the sale was made 
        public DateTime SaleDate { get; set; }

        //Customer
        public string Customer { get; set; }

        //Total sale amount 
        public decimal TotalSaleAmount { get; set; }

        //Branch where the sale was made 
        public string Branch { get; set; }

        //Products
        public List<SaleItem> Items { get; set; } = new List<SaleItem>();


        //Quantities 
        public int Quantity { get; set; }

        //Unit prices 
        public decimal UnitPrice { get; set; }

        //Discounts
        public decimal Discount { get; set; }

        //Total amount for each item 
        public decimal TotalItemAmount { get; set; }

        //Cancelled/Not Cancelled
        public bool IsCancelled { get; set; }

        public decimal TotalPrice => Items.Sum(i => i.TotalPrice);

        string ISalesRecords.Id => Id.ToString();



        public void AddItem(SaleItem item)
        {
            Items.Add(item);
            Quantity += item.Quantity;
            TotalItemAmount += item.TotalPrice;
            TotalSaleAmount += item.TotalPrice - item.Discount;
            Discount += item.Discount;
        }

        public void CancelSale()
        {
            IsCancelled = true;
            TotalSaleAmount = 0;
            Quantity = 0;
            TotalItemAmount = 0;
            Discount = 0;
            foreach (var item in Items)
            {
                item.Quantity = 0;
                item.TotalPrice = 0;
                item.Discount = 0;
            }
        }

        public void UpdateSale(string customer, string branch)
        {
            Customer = customer;
            Branch = branch;
        }

        public void ApplyDiscount(decimal discountAmount)
        {
            if (discountAmount < 0 || discountAmount > TotalSaleAmount)
                throw new ArgumentOutOfRangeException(nameof(discountAmount), "Discount amount must be between 0 and the total sale amount.");
            Discount += discountAmount;
            TotalSaleAmount -= discountAmount;
        }

        public void RemoveItem(SaleItem item)
        {
            if (Items.Remove(item))
            {
                Quantity -= item.Quantity;
                TotalItemAmount -= item.TotalPrice;
                TotalSaleAmount -= item.TotalPrice - item.Discount;
                Discount -= item.Discount;
            }
        }

        public void ClearItems()
        {
            Items.Clear();
            Quantity = 0;
            TotalItemAmount = 0;
            TotalSaleAmount = 0;
            Discount = 0;
        }

        public void CalculateDiscount()
        {
            if (Quantity < 4)
            {
                Discount = 0;
            }
            else if (Quantity >= 4 && Quantity < 10)
            {
                Discount = 0.10m; // 10% de desconto
            }
            else if (Quantity >= 10 && Quantity <= 20)
            {
                Discount = 0.20m; // 20% de desconto
            }
            else
            {
                throw new InvalidOperationException("Não é possível vender mais de 20 itens idênticos.");
            }
        }

        public void CalculateTotalItemAmount()
        {
            CalculateDiscount();
            TotalItemAmount = Quantity * UnitPrice * (1 - Discount);
        }


    }
}
