using LogisticsAndDeliveries.Core.Results;
using MediatR;

namespace LogisticsAndDeliveries.Application.Deliveries.MarkDeliveryCompleted
{
    public record MarkDeliveryCompletedCommand(
        Guid DeliveryId,
        string EvidencePhoto
    ) : IRequest<Result<bool>>;
}
