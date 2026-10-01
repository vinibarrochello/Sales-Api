using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.CancelSale
{
    public class CancelSaleRquestValidator
    : AbstractValidator<CancelSaleRequest>
    {
        public CancelSaleRquestValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty();
        }
    }
}
