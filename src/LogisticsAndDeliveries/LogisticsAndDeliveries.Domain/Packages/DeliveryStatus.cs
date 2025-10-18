namespace LogisticsAndDeliveries.Domain.Packages
{
    public enum DeliveryStatus
    {
        Pending = 0,
        InTransit = 1,
        Delivered = 2,
        Failed = 3,
        Cancelled = 4
    }
}