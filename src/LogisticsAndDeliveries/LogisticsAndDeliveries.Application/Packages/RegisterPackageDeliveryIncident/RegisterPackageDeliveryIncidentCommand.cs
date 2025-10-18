using LogisticsAndDeliveries.Core.Results;
using LogisticsAndDeliveries.Domain.Packages;
using MediatR;
using System;

namespace LogisticsAndDeliveries.Application.Packages.RegisterPackageDeliveryIncident
{
    public record RegisterPackageDeliveryIncidentCommand(
        Guid Id,
        DeliveryIncidentType Type,
        string Description,
        DateTime DateAndTimeOfDeliveryIncident
    ) : IRequest<Result<bool>>;
}
