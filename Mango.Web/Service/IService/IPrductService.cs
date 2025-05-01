using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
    public interface IPrductService
    {
        Task<ResponseDto?> GetProductAsync(int productId);
        Task<ResponseDto?> GetAllProductAsync();
        Task<ResponseDto?> GetProductByNamesAsync(string name);
        Task<ResponseDto?> CreateProductAsync(ProductDto productDto);
        Task<ResponseDto?> UpdateProductAsync(ProductDto productDto);
        Task<ResponseDto?> DeleteProductAsync(int id);
    }
}
