using LutryShop.CartApi.Models.Base;

namespace LutryShop.CartApi.Data.ValueObjects
{
    public class CartHeaderVO
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public string CouponCode { get; set; }
    }
}
