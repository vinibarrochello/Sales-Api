using Ambev.DeveloperEvaluation.Application.Sale.CancelSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.CancelSale
{
public class CancelSaleProfile : Profile
    {
        public CancelSaleProfile()
        {
            CreateMap<CancelSaleRequest, CancelSaleCommand>();

            CreateMap<CancelSaleResponse, CancelSaleResponse>();
        }
    }
}
