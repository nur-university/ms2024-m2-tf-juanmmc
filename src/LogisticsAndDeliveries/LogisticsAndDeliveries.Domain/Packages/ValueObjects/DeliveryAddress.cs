namespace LogisticsAndDeliveries.Domain.Packages.ValueObjects
{
    public record DeliveryAddress(
        string Address,
        double Latitude,
        double Longitude
    );
}