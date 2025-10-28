namespace LogisticsAndDeliveries.Application.Deliveries.Dto
{
    public record DeliveryDto
    {
        public Guid Id { get; set; }
        public required Guid PackageId { get; set; }
        public required Guid DriverId { get; set; }
        public DateOnly ScheduledDate { get; set; }
        public string? EvidencePhoto { get; set; }
        public string? IncidentType { get; set; }
        public string? IncidentDescription { get; set; }
        public int Order { get; set; }
        public required string Status { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
