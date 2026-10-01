namespace Ambev.DeveloperEvaluation.Application.Sale.GetSale
{
    using Ambev.DeveloperEvaluation.Domain.Repositories;
    using AutoMapper;
    using MediatR;

    public class GetSaleHandler
        : IRequestHandler<GetSaleCommand, GetSaleResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        public GetSaleHandler(
            ISaleRepository saleRepository,
            IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        public async Task<GetSaleResult> Handle(
            GetSaleCommand request,
            CancellationToken cancellationToken)
        {
            var sale = await _saleRepository
                .GetByIdAsync(
                    request.Id,
                    cancellationToken);

            if (sale is null)
                throw new KeyNotFoundException("Sale not found.");

            return _mapper.Map<GetSaleResult>(sale);
        }
    }
}
