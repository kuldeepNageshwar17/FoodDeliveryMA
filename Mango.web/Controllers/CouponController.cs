using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mango.web.Service.IService;
using Mango.web.Service;
using Mango.web.Models;
using Newtonsoft.Json;
using System.Collections;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mango.web
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;
        public CouponController(ICouponService couponservice)
        {
            _couponService = couponservice;
        }
        // GET: /<controller>/
        public async Task<IActionResult> CouponIndex()
        {
            List<CouponDto>? list = new();
            ResponseDto? response = await _couponService.GetAllCouponAsync();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(response.Result));
            }
            else {
                TempData["error"] = response?.Message;
            }

            return View(list);
        }

        public IActionResult CouponCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CouponCreate(CouponDto coupon)
        {
            if (ModelState.IsValid)
            {
                ResponseDto response = await _couponService.CreateCouponAsync(coupon);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Coupen created successfully !";

                    return RedirectToAction(nameof(CouponIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(coupon);
        }
        [HttpGet]
        public async Task<IActionResult> CouponDelete(int couponId )
        {
            ResponseDto? response = await _couponService.GetCouponByIdAsync(couponId);
            if (response != null && response.IsSuccess)
            {
               
                var coupen = JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(response.Result));
                return View(coupen);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();

        }
        [HttpPost]
        public async Task<IActionResult> CouponDelete(CouponDto  coupon )
        {
            ResponseDto? response = await _couponService.DeleteCouponAsync(coupon.CouponId);
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Coupen deleted successfully !";
                return RedirectToAction(nameof(CouponIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(coupon);
        }

    }
}

