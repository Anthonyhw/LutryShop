using LutryShop.Email.Models;
using Microsoft.EntityFrameworkCore;

namespace LutryShop.Email.Context
{
    public class MySqlContext : DbContext
    {
        public DbSet<EmailLog> Emails { get; set; }
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }

    }
}
