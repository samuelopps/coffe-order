using Coffee.Order.Core.Entities;

namespace Coffee.Order.Application.DTO.Request
{
    public class CreateCoffeeOrderRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public List<CoffeeDTO> CoffeesDTO { get; set; }

        public CoffeeOrderEntity ToEntity()
        {
            var coffees = CoffeesDTO.Select(x => new CoffeeEntity(x.Size, x.Type)).ToList();

            return new CoffeeOrderEntity(Name, Email, coffees);
        }
    }
}
