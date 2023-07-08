using Coffee.Order.Core.Entities;

namespace Coffee.Order.Core.Repositories
{
    public interface IOrderRepository
    {
        Task CreateAsync(CoffeeOrderEntity orderEntity);
        Task<CoffeeOrderEntity> GetByIdAsync(Guid guid);
        Task<CoffeeOrderEntity> GetByNameAsync(string name);
        Task UpdateAsync(CoffeeOrderEntity orderEntity);
    }
}
