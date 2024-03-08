using AutoMapper;
using LutryShop.CouponApi.Context;
using LutryShop.CouponApi.Data.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace LutryShop.CouponApi.Repositories
{
    public class CouponRepository : ICouponRepository
    {
        private readonly MySqlContext _context;
        private readonly IMapper _mapper;

        public CouponRepository(MySqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CouponVO> GetCouponByCode(string code)
        {
            var coupon = await _context.Coupons.FirstOrDefaultAsync(x => x.CouponCode == code);
            return _mapper.Map<CouponVO>(coupon);
        }
    }
}
