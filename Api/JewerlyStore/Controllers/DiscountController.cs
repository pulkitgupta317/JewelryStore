using JewelryStore.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JewelryStore.Controllers
{
    public class DiscountController : BaseController
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        [Route("GetDiscount")]
        public IActionResult GetDiscount()
        {
            return Ok(_discountService.GetDiscountByUserRole(UserRoleId));
        }
    }
}
