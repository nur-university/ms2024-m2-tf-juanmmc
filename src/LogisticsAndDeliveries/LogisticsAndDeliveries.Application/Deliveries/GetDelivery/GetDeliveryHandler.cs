using LogisticsAndDeliveries.Application.Deliveries.Dto;
using LogisticsAndDeliveries.Core.Results;
using LogisticsAndDeliveries.Domain.Deliveries;
using MediatR;

namespace LogisticsAndDeliveries.Application.Deliveries.GetDelivery
{
    internal class GetDeliveryHandler : IRequestHandler<GetDeliveryQuery, Result<DeliveryDto>>
    {
        private readonly IDeliveryRepository _deliveryRepository;

        public GetDeliveryHandler(IDeliveryRepository deliveryRepository)
        {
            _deliveryRepository = deliveryRepository;
        }

        public async Task<Result<DeliveryDto>> Handle(GetDeliveryQuery request, CancellationToken cancellationToken)
        {
            var delivery = await _deliveryRepository.GetByIdAsync(request.DeliveryId);
            if (delivery is null)
            {
                return Result<DeliveryDto>.ValidationFailure(DeliveryErrors.DeliveryNotFound);
            }
            var deliveryDto = new DeliveryDto
            {
                Id = delivery.Id,
                PackageId = delivery.PackageId,
                DriverId = delivery.DriverId,
                ScheduledDate = delivery.ScheduledDate,
                EvidencePhoto = delivery.EvidencePhoto,
                IncidentType = delivery.IncidentType?.ToString(),
                IncidentDescription = delivery.IncidentDescription,
                Order = delivery.Order,
                Status = delivery.Status.ToString(),
                UpdatedAt = delivery.UpdatedAt
            };
            return Result<DeliveryDto>.Success(deliveryDto);
        }
    }
}
