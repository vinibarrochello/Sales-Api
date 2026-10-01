namespace Ambev.DeveloperEvaluation.Application.Sale.GetSale
{
    using FluentValidation;

    public class GetSaleValidator : AbstractValidator<GetSaleCommand>
    {
        public GetSaleValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
