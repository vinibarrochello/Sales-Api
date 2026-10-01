using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public bool Active { get; private set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Product()
        {
            CreatedAt = DateTime.UtcNow;
            Active = true;
        }

        public ValidationResultDetail Validate()
        {
            var validator = new ProductValidator();

            var result = validator.Validate(this);

            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }

        public void Activate()
        {
            Active = true;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Deactivate()
        {
            Active = false;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
