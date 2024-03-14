using LutryShop.CartApi.Data.ValueObjects;
using LutryShop.CartApi.Messages;
using LutryShop.CartApi.RabbitMQSender;
using LutryShop.CartApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LutryShop.CartApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICouponRepository _couponRepository;
        private readonly IRabbitMQMessageSender _rabbitMQMessageSender;

        public CartController(ICartRepository cartRepository, IRabbitMQMessageSender rabbitMQMessageSender, ICouponRepository couponRepository)
        {
            _cartRepository = cartRepository;
            _rabbitMQMessageSender = rabbitMQMessageSender;
            _couponRepository = couponRepository;
        }

        [HttpGet("find-cart/{id}")]
        public async Task<ActionResult<CartVO>> FindById(string id) 
        {
            var cart = await _cartRepository.FindCartByUserId(id);
            if (cart == null) return NotFound();
            return Ok(cart);
        }

        [HttpPost("add-cart")]
        public async Task<ActionResult<CartVO>> AddCart(CartVO vo)
        {
            var cart = await _cartRepository.SaveOrUpdateCart(vo);
            if (cart == null) return NotFound();
            return Ok(cart);
        }

        [HttpPut("update-cart")]
        public async Task<ActionResult<CartVO>> UpdateCart(CartVO vo)
        {
            var cart = await _cartRepository.SaveOrUpdateCart(vo);
            if (cart == null) return NotFound();
            return Ok(cart);
        }

        [HttpDelete("remove-cart/{id}")]
        public async Task<ActionResult<CartVO>> RemoveCart(int id)
        {
            var status = await _cartRepository.RemoveFromCart(id);
            if (!status) return BadRequest();
            return Ok(status);
        }

        [HttpPost("apply-coupon")]
        public async Task<ActionResult<bool>> ApplyCoupon(CartVO vo)
        {
            var status = await _cartRepository.ApplyCoupon(vo.CartHeader.UserId, vo.CartHeader.CouponCode);
            if (!status) return NotFound();
            return Ok(status);
        }

        [HttpDelete("remove-coupon/{userId}")]
        public async Task<ActionResult<bool>> RemoveCoupon(string userId)
        {
            var status = await _cartRepository.RemoveCoupon(userId);
            if (!status) return BadRequest();
            return Ok(status);
        }
        [HttpPost("checkout")]
        public async Task<ActionResult<CheckoutHeaderVO>> Checkout(CheckoutHeaderVO vo)
        {
            if (vo?.UserId == null) return BadRequest();

            var cart = await _cartRepository.FindCartByUserId(vo.UserId);
            if (cart == null) return NotFound();

            if (!string.IsNullOrEmpty(vo.CouponCode)) {
                string token = Request.Headers["Authorization"];
                CouponVO coupon = await _couponRepository.GetCouponByCode(vo.CouponCode, token);
                if (vo.DiscountAmount != coupon.DiscountAmount) return StatusCode(412);
            } 

            vo.CartDetails = cart.CartDetails;
            vo.Time = DateTime.Now;

            _rabbitMQMessageSender.Send(vo, "checkout-queue");

            await _cartRepository.ClearCart(vo.UserId);
            return Ok(vo);
        }
    }
}
