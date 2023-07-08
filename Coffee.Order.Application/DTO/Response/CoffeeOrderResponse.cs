using Coffee.Order.Core.Entities;
using Coffee.Order.Core.Enums;

namespace Coffee.Order.Application.DTO.Response
{
    public class CoffeeOrderResponse
    {
        public CoffeeOrderResponse(Guid id, string name, CoffeeOrderStatus status, List<CoffeeDTO> coffeesDTO, DateTime createdDate)
        {
            Id = id;
            Name = name;
            Status = status;
            CoffeesDTO = coffeesDTO;
            CreatedDate = createdDate;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public CoffeeOrderStatus Status { get; private set; }
        public List<CoffeeDTO> CoffeesDTO { get; private set; }
        public DateTime CreatedDate { get; private set; }

        public static CoffeeOrderResponse FromEntity(CoffeeOrderEntity orderEntity)
        {
            var coffeesDTO = orderEntity.Coffees.Select(
                x => new CoffeeDTO() { Size = x.Size, Type = x.Type })
                .ToList();

            return new CoffeeOrderResponse(
                orderEntity.Id,
                orderEntity.Name,
                orderEntity.Status,
                coffeesDTO,
                orderEntity.CreatedDate);
        }
    }
}
