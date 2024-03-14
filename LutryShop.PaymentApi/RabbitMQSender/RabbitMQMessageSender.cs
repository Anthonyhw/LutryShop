using LutryShop.MessageBus;
using LutryShop.PaymentApi.Messages;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace LutryShop.PaymentApi.RabbitMQSender
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
            if (ConnectionExists())
            {
                using var channel = _connection.CreateModel();

                channel.QueueDeclare(queueName, false, false, false, null);

                byte[] body = GetMessageAsByteArray(message);

                channel.BasicPublish("", queueName, null, body);
            }

        }

        private byte[] GetMessageAsByteArray(BaseMessage message)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            var json = JsonSerializer.Serialize<UpdatePaymentResultMessage>((UpdatePaymentResultMessage)message, options);
            return Encoding.UTF8.GetBytes(json);
        }

        private bool ConnectionExists()
        {
            if (_connection != null) return true;
            CreateConnection();
            return _connection != null;
        }

        private void CreateConnection()
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = _hostname,
                    UserName = _username,
                    Password = _password,
                };
                _connection = factory.CreateConnection();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
