namespace Coffee.Order.Core.Entities
{
    public abstract class EntityBase
    {
        public EntityBase()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
        }

        public Guid Id { get; private set; }
        public DateTime CreatedDate { get; private set; }
    }
}