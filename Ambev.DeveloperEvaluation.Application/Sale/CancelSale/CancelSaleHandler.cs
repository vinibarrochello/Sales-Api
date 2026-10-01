using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sale.CancelSale
{
    public class CancelSaleHandler: IRequestHandler<CancelSaleCommand, CancelSaleResponse>
    {
        private readonly ISaleRepository _saleRepository;

        public CancelSaleHandler(
            ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<CancelSaleResponse> Handle(
            CancelSaleCommand request,
            CancellationToken cancellationToken)
        {
            var sale = await _saleRepository.GetByIdAsync(
                request.Id,
                cancellationToken);

            if (sale is null)
            {
                return new CancelSaleResponse
                {
                    Success = false,
                    Message = "Sale not found."
                };
            }

            sale.Cancel();

            await _saleRepository.UpdateAsync(
                sale,
                cancellationToken);

            return new CancelSaleResponse
            {
                Success = true,
                Message = "Sale cancelled successfully."
            };
        }
    }

}
