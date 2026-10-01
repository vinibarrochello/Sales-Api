namespace Ambev.DeveloperEvaluation.Application.Sale.CreateSale
{
    using Ambev.DeveloperEvaluation.Domain.Entities;
    using AutoMapper;

    public class CreateSaleProfile : Profile
    {
        public CreateSaleProfile()
        {
            CreateMap<CreateSaleCommand, Sale>();

            CreateMap<CreateSaleItemCommand, SaleProduct>();
        }
    }
}
