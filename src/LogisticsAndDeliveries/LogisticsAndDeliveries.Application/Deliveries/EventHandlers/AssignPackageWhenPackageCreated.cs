using LogisticsAndDeliveries.Domain.Deliveries;
using LogisticsAndDeliveries.Domain.Packages.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsAndDeliveries.Application.Deliveries.EventHandlers
{
    internal class AssignPackageWhenPackageCreated : INotificationHandler<PackageCreated>
    {
        private readonly IDeliveryRepository _deliveryRepository;
        // No unit of work needed here because it's handled by the infrastructure layer after event handling

        public AssignPackageWhenPackageCreated(IDeliveryRepository deliveryRepository)
        {
            _deliveryRepository = deliveryRepository;
        }

        public async Task Handle(PackageCreated domainEvent, CancellationToken cancellationToken)
        {
            var delivery = await _deliveryRepository.GetByIdAsync(domainEvent.DeliveryId);
            if (delivery != null)
            {
                delivery.AssignPackage(domainEvent.PackageId, domainEvent.ScheduleDeliveryDate);
                await _deliveryRepository.UpdateAsync(delivery);
            }
        }
    }
}
