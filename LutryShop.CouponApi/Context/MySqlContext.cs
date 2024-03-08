using LutryShop.CouponApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LutryShop.CouponApi.Context
{
    public class MySqlContext : DbContext
    {
        public DbSet<Coupon> Coupons { get; set; }
        public MySqlContext()
        { }
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coupon>().HasData(
                new[] {
                    new Coupon()
                    {
                        Id = 1,
                        CouponCode = "PROMO10",
                        DiscountAmount = 10
                    },
                    new Coupon()
                    {
                        Id = 2,
                        CouponCode = "PROMO12",
                        DiscountAmount = 20
                    }
                }
            );
        }
    }
}
