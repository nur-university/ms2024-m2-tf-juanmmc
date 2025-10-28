namespace LogisticsAndDeliveries.Application.Packages.Dto
{
    public record PackageDto
    {
        public Guid Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public  Guid PatientId { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public string PatientPhone { get; set; } = string.Empty;
        public string DeliveryAddress { get; set; } = string.Empty;
        public double DeliveryLatitude { get; set; }
        public double DeliveryLongitude { get; set; }
    }
}
