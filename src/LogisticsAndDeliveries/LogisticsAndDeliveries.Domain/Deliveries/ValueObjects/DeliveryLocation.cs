namespace LogisticsAndDeliveries.Domain.Deliveries.ValueObjects
{
    public record DeliveryLocation(
        double Latitude,
        double Longitude,
        DateTime Date
    );
}