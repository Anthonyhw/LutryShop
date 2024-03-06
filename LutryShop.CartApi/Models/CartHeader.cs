using LutryShop.CartApi.Models.Base;

namespace LutryShop.CartApi.Models
{
    public class CartHeader : BaseEntity
    {
        public string UserId { get; set; }
        public string CouponCode { get; set; }
    }
}
