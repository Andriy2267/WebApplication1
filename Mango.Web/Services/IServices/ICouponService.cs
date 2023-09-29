using Mango.Web.Dto;

namespace Mango.Web.Services.IServices
{
    public interface ICouponService
    {
        public Task<ResponseDto?> GetCouponByCodeAsync(string code);
        public Task<ResponseDto?> GetAllCouponsAsync();
        public Task<ResponseDto?> GetCouponByIdAsync(int id);
        public Task<ResponseDto?> UpdateCouponAsync(CouponDto couponDto);
        public Task<ResponseDto?> DeleteCouponAsync(int id);
        public Task<ResponseDto> CreateCouponAsync(CouponDto couponDto);
    }
}
