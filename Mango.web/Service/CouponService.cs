using Mango.web.Models;
using Mango.web.Service.IService;
using Mango.web.Utility;

namespace Mango.web.Service
{
    public class CouponService : ICouponService
    {

        private readonly IBaseService _baseService;
        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDTO> CreateCouponAsync(CouponDTO couponDTO)
        {
            return await _baseService.SendRequestAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = couponDTO,
                Url = SD.CouponAPIBase + "/api/coupon"

            });
        }

        public async Task<ResponseDTO> DeleteCouponAsync(int id)
        {
            return await _baseService.SendRequestAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.CouponAPIBase + "/api/coupon/" + id

            });
        }

        public async Task<ResponseDTO> GetAllCouponAsync()
        {
         return await _baseService.SendRequestAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CouponAPIBase + "/api/coupon"

            });
        }

        public async Task<ResponseDTO> GetCouponAsync(string couponCode)
        {
            return await _baseService.SendRequestAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CouponAPIBase + "/api/coupon/GetByCode/"+couponCode

            });
        }

        public async Task<ResponseDTO> GetCouponByIdAsync(int id)
        {
            return await _baseService.SendRequestAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CouponAPIBase + "/api/coupon/" + id

            });
        }

        public async Task<ResponseDTO> UpdateCouponAsync(CouponDTO couponDTO)
        {
            return await _baseService.SendRequestAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = couponDTO,
                Url = SD.CouponAPIBase + "/api/coupon"

            });
        }
    }
}
