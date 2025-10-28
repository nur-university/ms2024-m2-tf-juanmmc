using LogisticsAndDeliveries.Application.Drivers.Dto;
using LogisticsAndDeliveries.Core.Results;
using MediatR;

namespace LogisticsAndDeliveries.Application.Drivers.GetDrivers
{
    public record GetDriversQuery() : IRequest<Result<ICollection<DriverDto>>>;
}
