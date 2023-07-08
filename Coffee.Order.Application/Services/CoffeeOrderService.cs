using Coffee.Order.Application.DTO.Request;
using Coffee.Order.Application.DTO.Response;
using Coffee.Order.Application.Services.Interfaces;
using Coffee.Order.Core.Events;
using Coffee.Order.Core.Repositories;
using CoffeeOrder.Order.Core.Messaging;

namespace Coffee.Order.Application.Services
{
    public class CoffeeOrderService : ICoffeeOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMessageBusService _messageBus;

        public CoffeeOrderService(IOrderRepository orderRepository, IMessageBusService messageBus)
        {
            _orderRepository = orderRepository;
            _messageBus = messageBus;
        }

        public async Task<Guid> Create(CreateCoffeeOrderRequest request)
        {
            var orderEntity = request.ToEntity();
            
            await _orderRepository.CreateAsync(orderEntity);

            return orderEntity.Id;
        }

        public async Task<CoffeeOrderResponse> GetById(Guid id)
        {            
            var orderEntity = await _orderRepository.GetByIdAsync(id);

            return CoffeeOrderResponse.FromEntity(orderEntity);
        }

        public async Task<CoffeeOrderResponse> GetByName(string name)
        {
            var orderEntity = await _orderRepository.GetByNameAsync(name);

            return CoffeeOrderResponse.FromEntity(orderEntity);
        }

        public async Task SetCompleted(Guid id)
        {
            var orderEntity = await _orderRepository.GetByIdAsync(id);

            orderEntity.SetCompleted();

            await _orderRepository.UpdateAsync(orderEntity);

            var orderEvent = new CoffeeOrderCompletedEvent(orderEntity.Id);

            _messageBus.Publish(orderEvent, "customer-created");
        }
    }
}