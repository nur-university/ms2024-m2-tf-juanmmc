using LogisticsAndDeliveries.Application.Packages.Dto;
using LogisticsAndDeliveries.Core.Results;
using LogisticsAndDeliveries.Domain.Packages;
using MediatR;

namespace LogisticsAndDeliveries.Application.Packages.GetPackage
{
    internal class GetPackageHandler : IRequestHandler<GetPackageQuery, Result<PackageDto>>
    {
        private readonly IPackageRepository _packageRepository;

        public GetPackageHandler(IPackageRepository packageRepository)
        {
            _packageRepository = packageRepository;
        }

        public async Task<Result<PackageDto>> Handle(GetPackageQuery request, CancellationToken cancellationToken)
        {
            var package = await _packageRepository.GetByIdAsync(request.PackageId);
            if (package is null)
            {
                return Result<PackageDto>.ValidationFailure(PackageErrors.PackageNotFound);
            }
            var packageDto = new PackageDto
            {
                Id = package.Id,
                Number = package.Number,
                PatientId = package.PatientId,
                PatientName = package.PatientName,
                PatientPhone = package.PatientPhone,
                DeliveryAddress = package.DeliveryAddress,
                DeliveryLatitude = package.DeliveryLatitude,
                DeliveryLongitude = package.DeliveryLongitude
            };
            return Result<PackageDto>.Success(packageDto);
        }
    }
}
