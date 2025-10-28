using LogisticsAndDeliveries.Core.Results;
using MediatR;

namespace LogisticsAndDeliveries.Application.Drivers.UpdateDriverLocation
{
    public record UpdateDriverLocationCommand(Guid DriverId, double Latitude, double Longitude) : IRequest<Result<bool>>;
}
