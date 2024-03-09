using LutryShop.Web.Models;

namespace LutryShop.Web.Services.IServices
{
    public interface ICouponService
    {
        Task<CouponViewModel> GetCoupon(string code, string token);
    }
}
