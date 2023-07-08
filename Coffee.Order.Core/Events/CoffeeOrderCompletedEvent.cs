namespace Coffee.Order.Core.Events
{
    public class CoffeeOrderCompletedEvent
    {
        public CoffeeOrderCompletedEvent(Guid trackingCode)
        {
            TrackingCode = trackingCode;
        }

        public Guid TrackingCode { get; private set; }
    }
}
