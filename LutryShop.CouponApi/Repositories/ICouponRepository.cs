using LutryShop.CouponApi.Data.ValueObjects;

namespace LutryShop.CouponApi.Repositories
{
    public interface ICouponRepository
    {
        Task<CouponVO> GetCouponByCode(string code);
    }
}
