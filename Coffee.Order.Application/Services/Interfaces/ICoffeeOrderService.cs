using Coffee.Order.Application.DTO.Request;
using Coffee.Order.Application.DTO.Response;

namespace Coffee.Order.Application.Services.Interfaces
{
    public interface ICoffeeOrderService
    {
        Task<Guid> Create(CreateCoffeeOrderRequest request);
        Task<CoffeeOrderResponse> GetById(Guid id);
        Task<CoffeeOrderResponse> GetByName(string name);
        Task SetCompleted(Guid id);
    }
}
