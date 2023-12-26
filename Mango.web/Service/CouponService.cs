using System;
using Mango.web.Models;
using Mango.web.Service.IService;
using Mango.web.Utility;
using static Mango.web.Utility.SD;

namespace Mango.web.Service
{
    public class CouponService : ICouponService
	{
		private readonly IBaseService _baseService;
		public CouponService(IBaseService baseService)
		{
			_baseService = baseService;

		}
        public async Task<ResponseDto?> GetCouponAsync(string coupenCode)
		{
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CouponAPIBase + "/api/coupon/GetByCode"+coupenCode
            });
        }
       
        public async Task<ResponseDto?> GetAllCouponAsync() {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType= SD.ApiType.GET,
             Url=SD.CouponAPIBase+"/api/coupon"  
            });
        }

        public async Task<ResponseDto?> GetCouponByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CouponAPIBase + "/api/coupon/"+id
            });
        }
        public async Task<ResponseDto?> CreateCouponAsync(CouponDto coupon)
        {

            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data=coupon,
                Url = SD.CouponAPIBase + "/api/coupon"
            });

        }
        public  async Task<ResponseDto?> UpdateCouponAsync(CouponDto coupon)
		{
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data=coupon,
                Url = SD.CouponAPIBase + "/api/coupon"
            });
        }

        public  async  Task<ResponseDto?> DeleteCouponAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.CouponAPIBase + "/api/coupon/"+id
            });
        }
    }
}

