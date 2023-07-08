namespace CoffeeOrder.Order.Core.Messaging
{
    public interface IMessageBusService
    {
        void Publish(object data, string routingKey);
    }
}
