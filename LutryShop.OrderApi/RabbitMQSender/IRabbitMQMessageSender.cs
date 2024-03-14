using LutryShop.MessageBus;

namespace LutryShop.OrderApi.RabbitMQSender
{
    public interface IRabbitMQMessageSender
    {
        void Send(BaseMessage message, string queueName);
    }
}
