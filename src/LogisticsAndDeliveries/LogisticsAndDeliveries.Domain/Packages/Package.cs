using LogisticsAndDeliveries.Core.Abstractions;

namespace LogisticsAndDeliveries.Domain.Packages
{
    public class Package : AggregateRoot
    {
        public string Number { get; private set; }
        public Guid PatientId { get; private set; }
        public string PatientName { get; private set; }
        public string PatientPhone { get; private set; }
        public string DeliveryAddress { get; private set; }
        public double DeliveryLatitude { get; private set; }
        public double DeliveryLongitude { get; private set; }

        // Constructor para EF Core
        private Package() { }

        // Constructor de dominio
        public Package(Guid id, string number, Guid patientId, string patientName, string patientPhone, string deliveryAddress, double deliveryLatitude, double deliveryLongitude, DateOnly scheduledDate, Guid driverId) : base(id)
        {
            Number = number;
            PatientId = patientId;
            PatientName = patientName;
            PatientPhone = patientPhone;
            DeliveryAddress = deliveryAddress;
            DeliveryLatitude = deliveryLatitude;
            DeliveryLongitude = deliveryLongitude;

            AddDomainEvent(new Events.PackageCreated(id, driverId, scheduledDate));
        }
    }
}
