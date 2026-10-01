using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200);

            RuleFor(x => x.Description)
            .MaximumLength(1000);

            RuleFor(x => x.Price)
            .GreaterThan(0);
        }
    }
}
