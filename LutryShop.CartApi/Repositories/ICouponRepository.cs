using LutryShop.CartApi.Data.ValueObjects;

namespace LutryShop.CartApi.Repositories
{
    public interface ICouponRepository
    {
        Task<CouponVO> GetCouponByCode(string code, string token);
    }
}
