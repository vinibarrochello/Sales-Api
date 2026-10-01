using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class SaleProductValidator : AbstractValidator<SaleProduct>
    {
        public SaleProductValidator()
        {
            RuleFor(x => x.ProductId)
            .NotEmpty();

            RuleFor(x => x.ProductName)
            .NotEmpty()
            .MaximumLength(200);

            RuleFor(x => x.Quantity)
            .GreaterThan(0);

            RuleFor(x => x.Quantity)
            .LessThanOrEqualTo(20)
            .WithMessage("Cannot sell more than 20 identical items.");

            RuleFor(x => x.UnitPrice)
            .GreaterThan(0);
        }
    }
}
