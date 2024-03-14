using LutryShop.MessageBus;

namespace LutryShop.PaymentApi.RabbitMQSender
{
    public interface IRabbitMQMessageSender
    {
        void Send(BaseMessage message, string queueName);
    }
}
