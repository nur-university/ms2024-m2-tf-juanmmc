using LogisticsAndDeliveries.Core.Results;
using MediatR;

namespace LogisticsAndDeliveries.Application.Deliveries.MarkDeliveryFailed
{
    public record MarkDeliveryFailedCommand(Guid DeliveryId) : IRequest<Result<bool>>;
}
