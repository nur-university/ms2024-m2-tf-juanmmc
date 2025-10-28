using LogisticsAndDeliveries.Core.Results;
using LogisticsAndDeliveries.Domain.Deliveries;
using MediatR;

namespace LogisticsAndDeliveries.Application.Deliveries.RegisterDeliveryIncident
{
    public record RegisterDeliveryIncidentCommand(
        Guid DeliveryId,
        IncidentType IncidentType,
        string IncidentDescription
    ) : IRequest<Result<bool>>;
}
