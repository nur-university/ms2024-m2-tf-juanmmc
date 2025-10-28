using LogisticsAndDeliveries.Core.Results;
using MediatR;

namespace LogisticsAndDeliveries.Application.Deliveries.MarkDeliveryInTransit
{
    public record MarkDeliveryInTransitCommand(Guid DeliveryId) : IRequest<Result<bool>>;
}
