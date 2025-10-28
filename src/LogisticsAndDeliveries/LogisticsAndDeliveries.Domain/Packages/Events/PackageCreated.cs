using LogisticsAndDeliveries.Core.Abstractions;

namespace LogisticsAndDeliveries.Domain.Packages.Events
{
    public record PackageCreated : DomainEvent
    {
        public Guid PackageId { get; }
        public DateOnly ScheduledDate { get; }
        public Guid DriverId { get; }

        public PackageCreated(Guid packageId, Guid driverId, DateOnly scheduledDate)
        {
            PackageId = packageId;
            DriverId = driverId;
            ScheduledDate = scheduledDate;
        }

        public PackageCreated() { }
    }
}
