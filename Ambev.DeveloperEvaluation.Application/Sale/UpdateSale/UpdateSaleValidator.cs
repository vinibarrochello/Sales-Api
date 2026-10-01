namespace Ambev.DeveloperEvaluation.Application.Sale.UpdateSale
{
    using FluentValidation;

    public class UpdateSaleValidator
        : AbstractValidator<UpdateSaleCommand>
    {
        public UpdateSaleValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.BranchName)
                .NotEmpty();

            RuleFor(x => x.Items)
                .NotEmpty();

            RuleForEach(x => x.Items)
                .ChildRules(item =>
                {
                    item.RuleFor(x => x.ProductId)
                        .NotEmpty();

                    item.RuleFor(x => x.ProductName)
                        .NotEmpty();

                    item.RuleFor(x => x.Quantity)
                        .GreaterThan(0)
                        .LessThanOrEqualTo(20);

                    item.RuleFor(x => x.UnitPrice)
                        .GreaterThan(0);
                });
        }
    }
}
