using LutryShop.MessageBus;

namespace LutryShop.OrderApi.Messages
{
    public class UpdatePaymentResultVO: BaseMessage
    {
        public long OrderId { get; set; }
        public bool Status { get; set; }
        public string Email { get; set; }

    }
}
