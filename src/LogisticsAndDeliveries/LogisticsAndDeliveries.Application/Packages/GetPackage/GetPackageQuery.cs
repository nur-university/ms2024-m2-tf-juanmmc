using LogisticsAndDeliveries.Application.Packages.Dto;
using LogisticsAndDeliveries.Core.Results;
using MediatR;

namespace LogisticsAndDeliveries.Application.Packages.GetPackage
{
    public record GetPackageQuery(Guid PackageId) : IRequest<Result<PackageDto>>;
}
