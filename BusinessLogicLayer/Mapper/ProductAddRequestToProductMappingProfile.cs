
using AutoMapper;
using BusinessLogicLayer.DTO;
using eCommerce.DataAccessLayer.Entities;

namespace eCommerce.BusinessLogicLayer.Mapper;

public class ProductAddRequestToProductMappingProfile : Profile
{
    public ProductAddRequestToProductMappingProfile()
    {
        CreateMap<ProductUpdateRequest, Product>()
            .ForMember(dest => dest.ProductId, opt => opt.Ignore());

        CreateMap<ProductUpdateRequest, Product>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName));

        CreateMap<ProductUpdateRequest, Product>()
           .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));

        CreateMap<ProductUpdateRequest, Product>()
           .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice));

        CreateMap<ProductUpdateRequest, Product>()
           .ForMember(dest => dest.QuantityInStock, opt => opt.MapFrom(src => src.QuantityInStock));
    }
}
