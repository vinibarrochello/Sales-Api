using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.UpdateSale
{
    public class UpdateSaleRequestValidator
    : AbstractValidator<UpdateSaleRequest>
    {
        public UpdateSaleRequestValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty();

            RuleFor(x => x.BranchName)
            .NotEmpty();

            RuleFor(x => x.Items)
            .NotEmpty();
        }
    }
}
