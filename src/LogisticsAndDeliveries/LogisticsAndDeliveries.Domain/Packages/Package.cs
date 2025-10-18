using LogisticsAndDeliveries.Core.Abstractions;
using LogisticsAndDeliveries.Core.Results;
using LogisticsAndDeliveries.Domain.Packages.ValueObjects;

namespace LogisticsAndDeliveries.Domain.Packages
{
    public class Package : AggregateRoot
    {
        public PackageLabel PackageLabel { get; private set; }
        public EvidenceOfDelivery? EvidenceOfDelivery { get; private set; }
        public DeliveryStatus Status { get; private set; }
        private readonly List<DeliveryIncident> _deliveryIncidents = new();
        public IReadOnlyCollection<DeliveryIncident> DeliveryIncidents => _deliveryIncidents.AsReadOnly();

        // Constructor para EF Core (sin el parámetro packageLabel)
        private Package() { }

        // Constructor de dominio
        public Package(Guid id, PackageLabel packageLabel) : base(id)
        {
            PackageLabel = packageLabel;
            Status = DeliveryStatus.Pending;
            AddDomainEvent(new Events.PackageCreated(id, packageLabel.ScheduledDeliveryDate, packageLabel.DeliveryId));
        }

        public void MarkInTransit()
        {
            if (Status != DeliveryStatus.Pending) 
                throw new DomainException(PackageErrors.InvalidStatusTransition);
            Status = DeliveryStatus.InTransit;
        }

        public void MarkDelivered(EvidenceOfDelivery evidence)
        {
            if (Status != DeliveryStatus.InTransit)
                throw new DomainException(PackageErrors.InvalidStatusTransition);
            EvidenceOfDelivery = evidence;
            Status = DeliveryStatus.Delivered;
        }

        public void MarkFailed()
        {
            if (Status != DeliveryStatus.InTransit)
                throw new DomainException(PackageErrors.InvalidStatusTransition);
            Status = DeliveryStatus.Failed;
        }

        public void Cancel()
        {
            if (Status == DeliveryStatus.Delivered)
                throw new DomainException(PackageErrors.CannotCancelDeliveredPackage);
            Status = DeliveryStatus.Cancelled;
        }

        public void RegisterDeliveryIncident(DeliveryIncidentType type, string description, DateTime date)
        {
            if (Status != DeliveryStatus.Failed)
                throw new DomainException(PackageErrors.CannotRegisterIncidentInCurrentStatus);
            var incident = new DeliveryIncident(Guid.NewGuid(), type, description, date);
            _deliveryIncidents.Add(incident);
        }
    }
}
