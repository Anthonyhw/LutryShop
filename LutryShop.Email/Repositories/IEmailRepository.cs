using LutryShop.Email.Messages;

namespace LutryShop.Email.Repositories
{
    public interface IEmailRepository
    {
        Task LogEmail(UpdatePaymentResultMessage message);
    }
}
