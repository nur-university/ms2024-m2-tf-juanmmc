namespace LogisticsAndDeliveries.Domain.Deliveries.ValueObjects
{
    public record PackageAssignment(
        Guid PackageId,
        DateTime ScheduledDate
    );
}