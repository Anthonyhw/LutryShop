using LutryShop.CartApi.Messages;
using LutryShop.MessageBus;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace LutryShop.CartApi.RabbitMQSender
{
    public class RabbitMQMessageSender : IRabbitMQMessageSender
    {
        private readonly string _hostname;
        private readonly string _username;
        private readonly string _password;
        private IConnection _connection;

        public RabbitMQMessageSender()
        {
            _hostname = "localhost";
            _username = "guest";
            _password = "guest";
        }
        public void Send(BaseMessage message, string queueName)
        {
            var factory = new ConnectionFactory
            {
                HostName = _hostname,
                UserName = _username,
                Password = _password,
            };
            _connection = factory.CreateConnection();

            using var channel = _connection.CreateModel();

            channel.QueueDeclare(queueName, false, false, false, null);

            byte[] body = GetMessageAsByteArray(message);

            channel.BasicPublish("", queueName, null, body);
        }

        private byte[] GetMessageAsByteArray(BaseMessage message)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            var json = JsonSerializer.Serialize<CheckoutHeaderVO>((CheckoutHeaderVO)message, options);
            return Encoding.UTF8.GetBytes(json);
        }
    }
}
