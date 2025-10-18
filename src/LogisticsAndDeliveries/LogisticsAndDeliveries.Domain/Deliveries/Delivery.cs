using LogisticsAndDeliveries.Core.Abstractions;
using LogisticsAndDeliveries.Core.Results;
using LogisticsAndDeliveries.Domain.Deliveries.ValueObjects;
using LogisticsAndDeliveries.Domain.Packages.ValueObjects;

namespace LogisticsAndDeliveries.Domain.Deliveries
{
    public class Delivery : AggregateRoot
    {
        public string Name { get; private set; }
        private readonly List<PackageAssignment> _packageAssignments = new();
        public DeliveryLocation? DeliveryLocation { get; private set; }
        public IReadOnlyCollection<PackageAssignment> PackageAssignments => _packageAssignments.AsReadOnly();
        private readonly List<DeliveryRoute> _routes = new();
        public IReadOnlyCollection<DeliveryRoute> Routes => _routes.AsReadOnly();

        // Constructor para EF Core (sin el parámetro packageAssignments ni locations)
        private Delivery() { }

        // Constructor de dominio
        public Delivery(Guid id, string name) : base(id)
        {
            Name = name;
        }

        public void AssignPackage(Guid packageId, DateTime scheduledDeliveryDate)
        {
            if (_packageAssignments.Any(pa => pa.PackageId == packageId && pa.ScheduledDate.Date == scheduledDeliveryDate.Date))
                throw new DomainException(DeliveryErrors.PackageAlreadyAssigned);
            if (_routes.Any(r => r.ScheduledDate.Date == scheduledDeliveryDate.Date && r.Status != DeliveryRouteStatus.Cancelled))
                throw new DomainException(DeliveryErrors.CannotAssignPackageAfterRoutePlanned);
            _packageAssignments.Add(new PackageAssignment(packageId, scheduledDeliveryDate));
        }

        public void RegisterLocation(DeliveryLocation location)
        {
            DeliveryLocation = location;
        }

        public void PlanRoute(Guid routeId, DateTime scheduledDeliveryDate)
        {
            var assignmentsForDate = _packageAssignments
                .Where(pa => pa.ScheduledDate.Date == scheduledDeliveryDate.Date)
                .ToList();

            if (!assignmentsForDate.Any())
                throw new DomainException(DeliveryErrors.NoPackagesAssignedForDate);

            if (_routes.Any(r => r.ScheduledDate.Date == scheduledDeliveryDate.Date && r.Status != DeliveryRouteStatus.Cancelled))
                throw new DomainException(DeliveryErrors.RouteAlreadyPlannedForDate);

            var stops = assignmentsForDate
                .Select((pa, index) => new DeliveryStop(pa.PackageId, index + 1))
                .ToList();

            var route = new DeliveryRoute(routeId, scheduledDeliveryDate, DeliveryRouteStatus.Planned, stops);
            _routes.Add(route);
        }

        public void ReorderRouteStops(Guid routeId, List<Guid> orderedPackageIds)
        {
            var route = _routes.FirstOrDefault(r => r.Id == routeId);
            if (route == null)
                throw new DomainException(DeliveryErrors.RouteNotFound);
            route.ReorderStops(orderedPackageIds);
        }

        public void StartRoute(Guid routeId)
        {
            var route = _routes.FirstOrDefault(r => r.Id == routeId);
            if (route == null)
                throw new DomainException(DeliveryErrors.RouteNotFound);
            route.Start();
        }

        public void CompleteRoute(Guid routeId)
        {
            var route = _routes.FirstOrDefault(r => r.Id == routeId);
            if (route == null)
                throw new DomainException(DeliveryErrors.RouteNotFound);
            route.Complete();
        }

        public void CancelRoute(Guid routeId)
        {
            var route = _routes.FirstOrDefault(r => r.Id == routeId);
            if (route == null)
                throw new DomainException(DeliveryErrors.RouteNotFound);
            route.Cancel();
        }
    }
}