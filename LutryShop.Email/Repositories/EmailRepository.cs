
using LutryShop.Email.Context;
using LutryShop.Email.Messages;
using LutryShop.Email.Models;
using Microsoft.EntityFrameworkCore;

namespace LutryShop.Email.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        private readonly DbContextOptions<MySqlContext> _context;

        public EmailRepository(DbContextOptions<MySqlContext> context)
        {
            _context = context;
        }
        public async Task LogEmail(UpdatePaymentResultMessage message)
        {
            EmailLog email = new()
            {
                Email = message.Email,
                SentDate = DateTime.Now,
                Log = $"Order {message.OrderId} has been created successfuly!"
            };

            await using var _db = new MySqlContext(_context);
            
            _db.Emails.Add(email);
            
            await _db.SaveChangesAsync();
        }
    }
}
