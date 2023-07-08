using CoffeeOrder.Order.Core.Messaging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace CoffeeOrder.Infrastructure.Messeging
{
    public class RabbitMqService : IMessageBusService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private const string _exchange = "customers-service";

        public RabbitMqService()
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            _connection = connectionFactory.CreateConnection("customers-service-publisher");

            _channel = _connection.CreateModel();
        }

        public void Publish(object data, string routingKey)
        {
            var payload = JsonConvert.SerializeObject(data);
            var byteArray = Encoding.UTF8.GetBytes(payload);

            _channel.BasicPublish(_exchange, routingKey, null, byteArray);
        }
    }
}
