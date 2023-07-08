using Coffee.Order.Core.Entities;
using Coffee.Order.Core.Repositories;
using MongoDB.Driver;

namespace CoffeeOrder.Infrastructure.Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IMongoCollection<CoffeeOrderEntity> _collection;

        public OrderRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<CoffeeOrderEntity>("coffee-orders");
        }

        public async Task CreateAsync(CoffeeOrderEntity orderEntity)
        {
            await _collection.InsertOneAsync(orderEntity);
        }

        public async Task<CoffeeOrderEntity> GetByIdAsync(Guid id)
        {
            return await _collection.Find(c => c.Id == id).SingleOrDefaultAsync();
        }

        public async Task<CoffeeOrderEntity> GetByNameAsync(string name)
        {
            return await _collection.Find(c => c.Name == name).SingleOrDefaultAsync();
        }

        public async Task UpdateAsync(CoffeeOrderEntity orderEntity)
        {
            await _collection
                .ReplaceOneAsync(so => so.Id == orderEntity.Id, orderEntity);
        }
    }
}
