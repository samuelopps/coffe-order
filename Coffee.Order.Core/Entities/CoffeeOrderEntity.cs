using Coffee.Order.Core.Enums;

namespace Coffee.Order.Core.Entities
{
    public class CoffeeOrderEntity : EntityBase
    {
        public CoffeeOrderEntity(string name, string email, List<CoffeeEntity> coffees)
        {
            Name = name;            
            Email = email;
            Status = CoffeeOrderStatus.Created;
            Coffees = coffees;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }

        public CoffeeOrderStatus Status { get; private set; }
        public List<CoffeeEntity> Coffees { get; private set; }

        public void SetCompleted()
        {
            Status = CoffeeOrderStatus.Delivered;
        }
    }
}
