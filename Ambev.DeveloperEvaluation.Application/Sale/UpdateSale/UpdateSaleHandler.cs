namespace Ambev.DeveloperEvaluation.Application.Sale.UpdateSale
{
    using Ambev.DeveloperEvaluation.Domain.Entities;
    using Ambev.DeveloperEvaluation.Domain.Repositories;
    using MediatR;

    public class UpdateSaleHandler
        : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
    {
        private readonly ISaleRepository _saleRepository;

        public UpdateSaleHandler(
            ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<UpdateSaleResult> Handle(
            UpdateSaleCommand request,
            CancellationToken cancellationToken)
        {
            var sale = await _saleRepository.GetByIdAsync(
                request.Id,
                cancellationToken);

            if (sale is null)
                throw new KeyNotFoundException("Sale not found.");

            sale.BranchName = request.BranchName;

            sale.Items.Clear();

            foreach (var item in request.Items)
            {
                var saleProduct = new SaleProduct
                {
                    ProductId = item.ProductId,
                    ProductName = item.ProductName
                };

                saleProduct.Configure(
                    item.Quantity,
                    item.UnitPrice);

                sale.Items.Add(saleProduct);
            }

            sale.CalculateTotal();

            await _saleRepository.UpdateAsync(
                sale,
                cancellationToken);

            return new UpdateSaleResult
            {
                Id = sale.Id,
                SaleNumber = sale.SaleNumber,
                TotalAmount = sale.TotalAmount,
                IsCancelled = sale.IsCancelled
            };
        }
    }
}
