using LogisticsAndDeliveries.Core.Abstractions;

namespace LogisticsAndDeliveries.Domain.Packages.Events
{
    public record PackageCreated : DomainEvent
    {
        public Guid PackageId { get; }
        public DateTime ScheduleDeliveryDate { get; }
        public Guid DeliveryId { get; }

        public PackageCreated(Guid packageId, DateTime scheduleDeliveryDate, Guid deliveryId)
        {
            PackageId = packageId;
            ScheduleDeliveryDate = scheduleDeliveryDate;
            DeliveryId = deliveryId;
        }

        public PackageCreated() { }
    }
}
