using LogisticsAndDeliveries.Application.Deliveries.Dto;
using LogisticsAndDeliveries.Core.Results;
using MediatR;

namespace LogisticsAndDeliveries.Application.Deliveries.GetDelivery
{
    public record GetDeliveryQuery(Guid DeliveryId) : IRequest<Result<DeliveryDto>>;
}
