using AutoMapper;
using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Dto;
using Mango.Services.CouponAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponAPI.Controllers
{
    [Route("api/Coupon")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private ResponseDto _responseDto;
        private IMapper _mapping;
        public CouponAPIController(ApplicationDbContext context, IMapper mapping)
        {
            this._context = context;
            this._responseDto = new ResponseDto();
            this._mapping = mapping;
        }

        [HttpGet]
        public ResponseDto GetAllCoupons()
        {
            try
            {
                IEnumerable<Coupon> getCoupons = _context.Coupons.ToList();
                _responseDto.Result = _mapping.Map<IEnumerable<CouponDto>>(getCoupons);
            }
            catch (Exception ex)
            {
                _responseDto.Message = ex.Message;
                _responseDto.IsSuccess = false;
            }
            return _responseDto;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto GetCouponById(int id)
        {
            try
            {
                Coupon coupon = _context.Coupons.First(c => c.Id == id);

                if(coupon != null)
                {
                    _responseDto.Result = _mapping.Map<CouponDto>(coupon);
                }
            }
            catch (Exception ex)
            {
                _responseDto.Message = ex.Message;
                _responseDto.IsSuccess = false;
            }
            return _responseDto;
        }

        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDto GetByCode(string code)
        {
            try
            {
                Coupon getCouponByCode = _context.Coupons.First(c =>
                    c.CouponCode.ToLower() == code.ToLower());
                _responseDto.Result = _mapping.Map<CouponDto>(getCouponByCode);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [HttpPost]
        public ResponseDto CreateCoupon([FromBody] CouponDto couponDto)
        {
            try
            {
                Coupon coupon = _mapping.Map<Coupon>(couponDto);

                if (coupon != null)
                {
                    _context.Coupons.Add(coupon);
                    _context.SaveChanges();
                    _responseDto.Result = _mapping.Map<CouponDto>(coupon);
                }
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [HttpPut]
        public ResponseDto UpdateCoupon([FromBody] CouponDto couponDto)
        {
            try
            {
                Coupon coupon = _mapping.Map<Coupon>(couponDto);

                if (coupon != null)
                {
                    _context.Coupons.Update(coupon);
                    _context.SaveChanges();
                    _responseDto.Result = _mapping.Map<CouponDto>(coupon);
                }
            }
            catch (Exception ex)
            {
                _responseDto.Message = ex.Message;
                _responseDto.IsSuccess = false;
            }
            return _responseDto;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public ResponseDto DeleteCoupon(int id)
        {
            try
            {
                Coupon coupon = _context.Coupons.First(c => c.Id == id);
                _context.Remove(coupon);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _responseDto.Message = ex.Message;
                _responseDto.IsSuccess = false;
            }
            return _responseDto;
        }
    }
}
