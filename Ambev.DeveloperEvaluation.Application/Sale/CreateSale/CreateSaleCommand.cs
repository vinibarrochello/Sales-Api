using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sale.CreateSale
{
    public class CreateSaleCommand : IRequest<CreateSaleResult>
    {
        public Guid UserId { get; set; }

        public string Username { get; set; } = string.Empty;

        public string BranchName { get; set; } = string.Empty;

        public List<CreateSaleItemCommand> Items { get; set; } = [];
    }

    public class CreateSaleItemCommand
    {
        public Guid ProductId { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
    }


}
