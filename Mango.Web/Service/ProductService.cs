using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;
using System;

namespace Mango.Web.Service
{
    public class ProductService : IPrductService
    {
        private readonly IBaseService _baseService;

        public ProductService(IBaseService baseService)
        {
                _baseService = baseService;
        }

        public async Task<ResponseDto?> CreateProductAsync(ProductDto productDto)
        {
            return await _baseService.SendAsynch(new RequestDto
            {
                ApiType = SD.ApiType.POST,
                Data = productDto,
                Url = SD.ProducttAPIBase + "/api/product"
            });
        }

        public async Task<ResponseDto?> DeleteProductAsync(int id)
        {
            return await _baseService.SendAsynch(new RequestDto
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.ProducttAPIBase + "/api/product?id=" + id
            });
        }

        public async Task<ResponseDto?> GetAllProductAsync()
        {
            return await _baseService.SendAsynch(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ProducttAPIBase + "/api/product"
            });
        }

        public async Task<ResponseDto?> GetProductAsync(int productId)
        {
            return await _baseService.SendAsynch(new RequestDto
            {
                ApiType= SD.ApiType.GET,
                Url = SD.ProducttAPIBase + "/api/product/" + productId  
            });
        }

        public async Task<ResponseDto?> GetProductByNamesAsync(string name)
        {
            return await _baseService.SendAsynch(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ProducttAPIBase + "/api/product/" + name
            });
        }

        public async Task<ResponseDto?> UpdateProductAsync(ProductDto productDto)
        {
            return await _baseService.SendAsynch(new RequestDto
            {
                ApiType =  SD.ApiType.PUT,
                Data = productDto,
                Url = SD.ProducttAPIBase + "/api/product"
            });
        }
    }
}
