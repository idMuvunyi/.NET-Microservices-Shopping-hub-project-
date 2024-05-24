using Mango.web.Models;

namespace Mango.web.Service.IService
{
    public interface ICouponService
    {
        Task<ResponseDTO> GetCouponAsync(string couponCode);
        Task<ResponseDTO> GetAllCouponAsync();
        Task<ResponseDTO> GetCouponByIdAsync(int id);
        Task<ResponseDTO> CreateCouponAsync(CouponDTO couponDTO);
        Task<ResponseDTO> UpdateCouponAsync(CouponDTO couponDTO);
        Task<ResponseDTO> DeleteCouponAsync(int id);


    }
}
