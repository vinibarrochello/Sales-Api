namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.CreateSale
{
    public class CreateSaleResponse
    {
        public Guid Id { get; set; }

        public string SaleNumber { get; set; } = string.Empty;

        public decimal TotalAmount { get; set; }

        public bool IsCancelled { get; set; }
    }
}
