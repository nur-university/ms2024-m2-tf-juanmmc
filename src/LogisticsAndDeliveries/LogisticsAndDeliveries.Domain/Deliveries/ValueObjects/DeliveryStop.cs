namespace LogisticsAndDeliveries.Domain.Deliveries.ValueObjects
{
    public record DeliveryStop(
        Guid PackageId,
        int Order
    );
}