using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
    public interface ICartService
    {
        Task<ResponseDto?> GetCartByUserIdAsych(string userId);
        Task<ResponseDto?> UpsertCartAsych(CartDto cartDto);
        Task<ResponseDto?> RemoveFromCartAsych(int cartDetailsId);
        Task<ResponseDto?> ApplyCouponAsych(CartDto cartDto);
    }
}
