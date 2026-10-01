namespace Ambev.DeveloperEvaluation.Application.Sale.UpdateSale
{
    public class UpdateSaleResult
    {
        public Guid Id { get; set; }

        public string SaleNumber { get; set; } = string.Empty;

        public decimal TotalAmount { get; set; }

        public bool IsCancelled { get; set; }
    }
}
