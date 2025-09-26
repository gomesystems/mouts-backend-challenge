using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSales
{
    public class CreateSalesCommand : IRequest<CreateSalesResult>
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime SaleDate { get; set; }


        public string? ProductName { get; set; } // Added to facilitate validation
        public string ProductDescription { get; set; } = string.Empty;


        public ValidationResultDetail Validate()
        {
            var validator = new CreateSalesCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(oo => (ValidationErrorDetail)oo)
            };
        }
    }
}
