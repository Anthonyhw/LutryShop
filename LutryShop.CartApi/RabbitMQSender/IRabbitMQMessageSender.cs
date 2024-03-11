using LutryShop.MessageBus;

namespace LutryShop.CartApi.RabbitMQSender
{
    public interface IRabbitMQMessageSender
    {
        void Send(BaseMessage message, string queueName);
    }
}
