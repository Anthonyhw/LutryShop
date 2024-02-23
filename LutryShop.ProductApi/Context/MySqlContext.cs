using LutryShop.ProductApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LutryShop.ProductApi.Context
{
    public class MySqlContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public MySqlContext()
        { }
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }
    }
}
