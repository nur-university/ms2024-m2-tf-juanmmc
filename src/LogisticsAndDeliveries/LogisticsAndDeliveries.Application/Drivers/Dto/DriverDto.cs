namespace LogisticsAndDeliveries.Application.Drivers.Dto
{
    public record DriverDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public DateTime? LastLocationUpdate { get; set; }
    }
}
