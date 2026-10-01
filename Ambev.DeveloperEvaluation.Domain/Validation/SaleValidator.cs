using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class SaleValidator : AbstractValidator<Sale>
    {
        public SaleValidator()
        {
            RuleFor(x => x.SaleNumber)
            .NotEmpty()
            .MaximumLength(50);

            RuleFor(x => x.SaleDate)
            .NotEmpty();

            RuleFor(x => x.UserId)
            .NotEmpty();

            RuleFor(x => x.Username)
            .NotEmpty()
            .MaximumLength(100);

            RuleFor(x => x.BranchName)
            .NotEmpty()
            .MaximumLength(200);

            RuleFor(x => x.Items)
            .NotEmpty()
            .WithMessage("A sale must contain at least one item.");

            RuleForEach(x => x.Items)
            .SetValidator(new SaleProductValidator());
        }
    }
}
