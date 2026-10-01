namespace Ambev.DeveloperEvaluation.Application.Sale.GetSale
{
    public class GetSaleResult
    {
        public Guid Id { get; set; }

        public string SaleNumber { get; set; } = string.Empty;

        public DateTime SaleDate { get; set; }

        public string Username { get; set; } = string.Empty;

        public string BranchName { get; set; } = string.Empty;

        public decimal TotalAmount { get; set; }

        public bool IsCancelled { get; set; }

        public IEnumerable<GetSaleItemResult> Items { get; set; } = [];
    }

    public class GetSaleItemResult
    {
        public string ProductName { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
