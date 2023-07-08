using Coffee.Order.Core.Enums;

namespace Coffee.Order.Core.Entities
{
    public class CoffeeEntity : EntityBase
    {
        public CoffeeEntity(CoffeeSize size, CoffeeType type)
        {
            Size = size;
            Type = type;
        }

        public CoffeeSize Size { get; private set; }
        public CoffeeType Type { get; private set; }
    }
}
