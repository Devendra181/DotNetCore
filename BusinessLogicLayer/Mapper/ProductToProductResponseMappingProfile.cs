using AutoMapper;
using BusinessLogicLayer.DTO;
using eCommerce.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Mapper;

public class ProductToProductResponseMappingProfile: Profile
{
    public ProductToProductResponseMappingProfile()
    {
        CreateMap<Product, ProductResponse>()
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId));

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
