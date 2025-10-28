using LogisticsAndDeliveries.Core.Results;
using MediatR;

namespace LogisticsAndDeliveries.Application.Deliveries.CancelDelivery
{
    public record CancelDeliveryCommand(Guid DeliveryId) : IRequest<Result<bool>>;
}
