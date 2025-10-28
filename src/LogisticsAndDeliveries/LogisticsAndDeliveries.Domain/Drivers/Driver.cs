using LogisticsAndDeliveries.Core.Abstractions;

namespace LogisticsAndDeliveries.Domain.Drivers
{
    public class Driver : AggregateRoot
    {
        public string Name { get; private set; }
        public double? Longitude { get; private set; }
        public double? Latitude { get; private set; }
        public DateTime? LastLocationUpdate { get; private set; }
        
        
        // Constructor para EF Core
        private Driver() { }

        // Constructor de dominio
        public Driver(Guid id, string name) : base(id)
        {
            Name = name;
        }

        public void UpdateLocation(double longitude, double latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
            LastLocationUpdate = DateTime.UtcNow;
        }
    }
}