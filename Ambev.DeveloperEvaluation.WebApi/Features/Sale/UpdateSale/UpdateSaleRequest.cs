namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.UpdateSale
{
    public class UpdateSaleRequest
    {
        public Guid Id { get; set; }

        public string BranchName { get; set; } = string.Empty;

        public List<UpdateSaleItemRequest> Items { get; set; } = [];
    }

    public class UpdateSaleItemRequest
    {
        public Guid ProductId { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
