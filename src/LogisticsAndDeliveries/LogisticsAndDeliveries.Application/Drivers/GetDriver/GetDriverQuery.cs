using LogisticsAndDeliveries.Application.Drivers.Dto;
using LogisticsAndDeliveries.Core.Results;
using MediatR;

namespace LogisticsAndDeliveries.Application.Drivers.GetDriver
{
    public record GetDriverQuery(Guid DriverId) : IRequest<Result<DriverDto>>;
}
