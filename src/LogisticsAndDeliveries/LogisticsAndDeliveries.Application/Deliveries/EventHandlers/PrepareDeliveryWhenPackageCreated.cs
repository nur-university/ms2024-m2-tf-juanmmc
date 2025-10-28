using LogisticsAndDeliveries.Domain.Deliveries;
using LogisticsAndDeliveries.Domain.Packages.Events;
using MediatR;

namespace LogisticsAndDeliveries.Application.Deliveries.EventHandlers
{
    internal class PrepareDeliveryWhenPackageCreated : INotificationHandler<PackageCreated>
    {
        private readonly IDeliveryRepository _deliveryRepository;
        // No unit of work needed here because it's handled by the infrastructure layer after event handling

        public PrepareDeliveryWhenPackageCreated(IDeliveryRepository deliveryRepository)
        {
            _deliveryRepository = deliveryRepository;
        }

        public async Task Handle(PackageCreated domainEvent, CancellationToken cancellationToken)
        {
            var delivery = new Delivery(
                Guid.NewGuid(),
                domainEvent.PackageId,
                domainEvent.DriverId,
                domainEvent.ScheduledDate
            );
            await _deliveryRepository.AddAsync(delivery);
        }
    }
}
