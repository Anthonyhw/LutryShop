using LutryShop.OrderApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LutryShop.OrderApi.Context
{
    public class MySqlContext : DbContext
    {
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }

    }
}
