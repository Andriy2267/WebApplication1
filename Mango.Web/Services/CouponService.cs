﻿using Mango.Web.Dto;
using Mango.Web.Services.IServices;
using static Mango.Web.Utility.SD;

namespace Mango.Web.Services
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;
        public CouponService(IBaseService baseService)
        {
            this._baseService = baseService;
        }
        public async Task<ResponseDto> CreateCouponAsync(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.POST,
                Data = couponDto,
                Url = CouponAPIBase + "/api/coupon"
            });
        }

        public async Task<ResponseDto?> DeleteCouponAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.DELETE,
                Url = CouponAPIBase + "/api/coupon/" + id
            });
        }

        public async Task<ResponseDto?> GetAllCouponsAsync()
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = ApiType.GET,
                Url = CouponAPIBase + "/api/coupon"
            });
        }

        public async Task<ResponseDto?> GetCouponByCodeAsync(string code)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = ApiType.GET,
                Url = CouponAPIBase + "/api/coupon/GetByCode/" + code
            });
        }

        public async Task<ResponseDto?> GetCouponByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = CouponAPIBase + "/api/coupon/" + id
            });
        }

        public async Task<ResponseDto?> UpdateCouponAsync(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.PUT,
                Data = couponDto,
                Url = CouponAPIBase + "/api/coupon"
            });
        }
    }
}
