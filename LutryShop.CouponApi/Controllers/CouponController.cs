using LutryShop.CouponApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LutryShop.CouponApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CouponController : ControllerBase
    {
        private readonly ICouponRepository _couponRepository;

        public CouponController(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository;
        }

        [HttpGet("{code}")]
        public async Task<ActionResult> GetCouponByCode(string code)
        {
            var response = await _couponRepository.GetCouponByCode(code);
            if (response != null) return Ok(response);

            return NotFound();
        }
    }
}
