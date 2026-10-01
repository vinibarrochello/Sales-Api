namespace Ambev.DeveloperEvaluation.Application.Sale.UpdateSale
{
    using Ambev.DeveloperEvaluation.Domain.Entities;
    using AutoMapper;

    public class UpdateSaleProfile : Profile
    {
        public UpdateSaleProfile()
        {
            CreateMap<UpdateSaleCommand, Sale>();

            CreateMap<UpdateSaleItemCommand, SaleProduct>();
        }
    }
}
