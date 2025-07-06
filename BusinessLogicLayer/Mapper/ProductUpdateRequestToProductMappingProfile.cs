using AutoMapper;
using eCommerce.BusinessLogicLayer.DTO;
using eCommerce.DataAccessLayer.Entities;


namespace BusinessLogicLayer.Mapper;

public class ProductUpdateRequestToProductMappingProfile: Profile
{
    public ProductUpdateRequestToProductMappingProfile()
    {

      CreateMap<ProductUpdateRequest, Product>()
      .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.productId))
      .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
      .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
      .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice))
      .ForMember(dest => dest.QuantityInStock, opt => opt.MapFrom(src => src.QuantityInStock))
      ;
    }
}
