using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SaleProduct : BaseEntity
    {
        public Guid SaleId { get; set; }

        public Guid ProductId { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public int Quantity { get; private set; }

        public decimal UnitPrice { get; private set; }

        public decimal DiscountPercentage { get; private set; }

        public decimal DiscountAmount { get; private set; }

        public decimal TotalAmount { get; private set; }

        public bool IsCancelled { get; private set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public SaleProduct()
        {
            CreatedAt = DateTime.UtcNow;
        }

        public ValidationResultDetail Validate()
        {
            var validator = new SaleProductValidator();

            var result = validator.Validate(this);

            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }

        public void Configure(
            int quantity,
            decimal unitPrice)
        {
            if (quantity > 20)
                throw new DomainException("Cannot sell more than 20 identical items.");

            Quantity = quantity;
            UnitPrice = unitPrice;

            CalculateDiscount();
        }

        private void CalculateDiscount()
        {
            if (Quantity >= 10)
            {
                DiscountPercentage = 20;
            }
            else if (Quantity >= 4)
            {
                DiscountPercentage = 10;
            }
            else
            {
                DiscountPercentage = 0;
            }

            var grossAmount = Quantity * UnitPrice;

            DiscountAmount = grossAmount * (DiscountPercentage / 100);

            TotalAmount = grossAmount - DiscountAmount;

            UpdatedAt = DateTime.UtcNow;
        }

        public void Cancel()
        {
            IsCancelled = true;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
