namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.CreateSale
{
    public class CreateSaleRequest
    {
        public Guid UserId { get; set; }

        public string Username { get; set; } = string.Empty;

        public string BranchName { get; set; } = string.Empty;

        public List<CreateSaleItemRequest> Items { get; set; } = [];
    }

    public class CreateSaleItemRequest
    {
        public Guid ProductId { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
