using Mango.Web.Dto;
using Mango.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Mango.Web.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;
        public CouponController(ICouponService couponService)
        {
            this._couponService = couponService;
        }

        public async Task<IActionResult> CouponIndex()
        {
            List<CouponDto> list = new List<CouponDto>();

            ResponseDto? responseDto = await _couponService.GetAllCouponsAsync();

            if(responseDto != null && responseDto.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(responseDto.Result));
            }
            return View(list);
        }

        public async Task<IActionResult> CreateCoupon()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCoupon(CouponDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _couponService.CreateCouponAsync(model);

                if(response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(CouponIndex));
                }
            }
            return View(model);
        }

        public async Task<IActionResult> DeleteCoupon(int couponId)
        {
            ResponseDto? responseDto = await _couponService.GetCouponByIdAsync(couponId);

            if(responseDto != null && responseDto.IsSuccess)
            {
                CouponDto? model = JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(responseDto.Result));
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCoupon(CouponDto couponDto)
        {
            ResponseDto? responseDto = await _couponService.DeleteCouponAsync(couponDto.Id);

            if(responseDto != null && responseDto.IsSuccess)
            {
                return RedirectToAction(nameof(CouponIndex));
            }
            return View(couponDto);
        }
    }
}
