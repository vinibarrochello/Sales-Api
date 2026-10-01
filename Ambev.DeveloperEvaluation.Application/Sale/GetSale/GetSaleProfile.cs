using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sale.GetSale
{
    public class GetSaleProfile : Profile
    {
        public GetSaleProfile()
        {
            CreateMap<Ambev.DeveloperEvaluation.Domain.Entities.Sale, GetSaleResult>();

            CreateMap<SaleProduct, GetSaleItemResult>();
        }
    }
}
