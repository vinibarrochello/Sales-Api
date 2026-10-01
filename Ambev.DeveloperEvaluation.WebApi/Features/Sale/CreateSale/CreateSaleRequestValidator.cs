using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.CreateSale
{
    public class CreateSaleRequestValidator
    : AbstractValidator<CreateSaleRequest>
    {
        public CreateSaleRequestValidator()
        {
            RuleFor(x => x.UserId)
            .NotEmpty();

            RuleFor(x => x.Username)
            .NotEmpty();

            RuleFor(x => x.BranchName)
            .NotEmpty();

            RuleFor(x => x.Items)
            .NotEmpty();
        }
    }
}
