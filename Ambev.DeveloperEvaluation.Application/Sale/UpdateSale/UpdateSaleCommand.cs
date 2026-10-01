using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sale.UpdateSale
{
    public class UpdateSaleCommand : IRequest<UpdateSaleResult>
    {
        public Guid Id { get; set; }

        public string BranchName { get; set; } = string.Empty;

        public List<UpdateSaleItemCommand> Items { get; set; } = [];
    }

    public class UpdateSaleItemCommand
    {
        public Guid ProductId { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
    }

}
