using Ambev.DeveloperEvaluation.Application.Sale.UpdateSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.UpdateSale
{
    public class UpdateSaleProfile : Profile
    {
        public UpdateSaleProfile()
        {
            CreateMap<UpdateSaleRequest, UpdateSaleCommand>();

            CreateMap<UpdateSaleResult, UpdateSaleResponse>();
        }
    }
}
