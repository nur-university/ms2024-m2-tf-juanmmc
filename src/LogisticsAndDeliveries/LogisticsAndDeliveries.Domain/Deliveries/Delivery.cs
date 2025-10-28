using LogisticsAndDeliveries.Core.Abstractions;
using LogisticsAndDeliveries.Core.Results;

namespace LogisticsAndDeliveries.Domain.Deliveries
{
    public class Delivery : AggregateRoot
    {
        public Guid PackageId { get; private set; }
        public Guid DriverId { get; private set; }
        public DateOnly ScheduledDate { get; private set; }
        public string? EvidencePhoto { get; private set; }
        public IncidentType? IncidentType { get; private set; }
        public string? IncidentDescription { get; private set; }
        public int Order {  get; private set; }
        public DeliveryStatus Status { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        // Constructor para EF Core
        private Delivery() { }

        // Constructor de dominio
        public Delivery(Guid id, Guid packageId, Guid driverId, DateOnly scheduledDate) : base(id)
        {
            PackageId = packageId;
            DriverId = driverId;
            ScheduledDate = scheduledDate;
            Order = 0;
            Status = DeliveryStatus.Pending;
        }

        public void SetOrder(int order)
        {
            if (order <= 0)
                throw new DomainException(DeliveryErrors.InvalidOrderValue);

            if (Status != DeliveryStatus.Pending)
                throw new DomainException(DeliveryErrors.InvalidStatusTransition);

            Order = order;
            UpdatedAt = DateTime.UtcNow;
        }

        public void MarkInTransit()
        {
            if (Order <= 0)
                throw new DomainException(DeliveryErrors.InvalidOrderValue);

            if (Status != DeliveryStatus.Pending) 
                throw new DomainException(DeliveryErrors.InvalidStatusTransition);

            Status = DeliveryStatus.InTransit;
            UpdatedAt = DateTime.UtcNow;
        }

        public void MarkCompleted(string evidencePhoto)
        {
            if (Status != DeliveryStatus.InTransit)
                throw new DomainException(DeliveryErrors.InvalidStatusTransition);
            EvidencePhoto = evidencePhoto;
            Status = DeliveryStatus.Completed;
            UpdatedAt = DateTime.UtcNow;
        }

        public void MarkFailed()
        {
            if (Status != DeliveryStatus.InTransit)
                throw new DomainException(DeliveryErrors.InvalidStatusTransition);
            Status = DeliveryStatus.Failed;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Cancel()
        {
            if (Status == DeliveryStatus.Completed)
                throw new DomainException(DeliveryErrors.CannotCancelCompletedDelivery);
            Status = DeliveryStatus.Cancelled;
            UpdatedAt = DateTime.UtcNow;
        }

        public void RegisterDeliveryIncident(IncidentType incidentType, string incidentDescription)
        {
            if (Status != DeliveryStatus.Failed)
                throw new DomainException(DeliveryErrors.CannotRegisterIncidentInCurrentStatus);
            IncidentType = incidentType;
            IncidentDescription = incidentDescription;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
