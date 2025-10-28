using LogisticsAndDeliveries.Core.Results;
using MediatR;

namespace LogisticsAndDeliveries.Application.Packages.CreatePackage
{
    public record CreatePackageCommand(Guid Id, string Number, Guid PatientId, string PatientName, string PatientPhone, string DeliveryAddress, double DeliveryLatitude, double DeliveryLongitude, DateOnly ScheduledDate, Guid DriverId) : IRequest<Result<Guid>>;
}
