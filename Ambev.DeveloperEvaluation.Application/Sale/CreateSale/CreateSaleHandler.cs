namespace Ambev.DeveloperEvaluation.Application.Sale.CreateSale
{
    using Ambev.DeveloperEvaluation.Domain.Entities;
    using Ambev.DeveloperEvaluation.Domain.Repositories;
    using AutoMapper;
    using MediatR;

    public class CreateSaleHandler
        : IRequestHandler<CreateSaleCommand, CreateSaleResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        public CreateSaleHandler(
            ISaleRepository saleRepository,
            IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        public async Task<CreateSaleResult> Handle(
            CreateSaleCommand request,
            CancellationToken cancellationToken)
        {
            var sale = new Sale
            {
                SaleNumber = Guid.NewGuid().ToString("N")[..8].ToUpper(),
                SaleDate = DateTime.UtcNow,
                UserId = request.UserId,
                Username = request.Username,
                BranchName = request.BranchName
            };

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

            await _saleRepository.CreateAsync(
                sale,
                cancellationToken);

            return new CreateSaleResult
            {
                Id = sale.Id,
                SaleNumber = sale.SaleNumber,
                TotalAmount = sale.TotalAmount,
                IsCancelled = sale.IsCancelled
            };
        }
    }
}
