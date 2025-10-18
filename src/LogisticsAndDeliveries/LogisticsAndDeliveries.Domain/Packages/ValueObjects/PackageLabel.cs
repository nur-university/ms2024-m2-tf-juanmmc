namespace LogisticsAndDeliveries.Domain.Packages.ValueObjects
{
    public record PackageLabel
    {
        public string IdentificationNumber { get; init; }
        public DateTime ScheduledDeliveryDate { get; init; }
        public Guid DeliveryId { get; init; }
        public PatientData PatientData { get; init; }
        public DeliveryAddress DeliveryAddress { get; init; }

        // Constructor sin parámetros requerido por EF Core
        public PackageLabel() { }

        // Constructor de conveniencia para tu dominio
        public PackageLabel(
            string identificationNumber,
            DateTime scheduledDeliveryDate,
            Guid deliveryId,
            PatientData patientData,
            DeliveryAddress deliveryAddress)
        {
            IdentificationNumber = identificationNumber;
            ScheduledDeliveryDate = scheduledDeliveryDate;
            DeliveryId = deliveryId;
            PatientData = patientData;
            DeliveryAddress = deliveryAddress;
        }
    }
}