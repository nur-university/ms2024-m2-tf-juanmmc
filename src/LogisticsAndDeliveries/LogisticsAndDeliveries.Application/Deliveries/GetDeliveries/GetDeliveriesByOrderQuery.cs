using LogisticsAndDeliveries.Application.Deliveries.Dto;
using LogisticsAndDeliveries.Core.Results;
using MediatR;

namespace LogisticsAndDeliveries.Application.Deliveries.GetDeliveries
{
    public record GetDeliveriesByOrderQuery(Guid DriverId, DateOnly ScheduledDate) : IRequest<Result<ICollection<DeliveryDto>>>;
}
