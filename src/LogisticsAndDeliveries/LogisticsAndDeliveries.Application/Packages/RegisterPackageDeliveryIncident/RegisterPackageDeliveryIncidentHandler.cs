using LogisticsAndDeliveries.Core.Abstractions;
using LogisticsAndDeliveries.Core.Results;
using LogisticsAndDeliveries.Domain.Packages;
using MediatR;
using System;
using System.Threading.Tasks;

namespace LogisticsAndDeliveries.Application.Packages.RegisterPackageDeliveryIncident
{
    internal class RegisterPackageDeliveryIncidentHandler : IRequestHandler<RegisterPackageDeliveryIncidentCommand, Result<bool>>
    {
        private readonly IPackageRepository _packageRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterPackageDeliveryIncidentHandler(IPackageRepository packageRepository, IUnitOfWork unitOfWork)
        {
            _packageRepository = packageRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(RegisterPackageDeliveryIncidentCommand request, CancellationToken cancellationToken)
        {
            var package = await _packageRepository.GetByIdAsync(request.Id);

            if (package == null)
                return Result<bool>.ValidationFailure(PackageErrors.PackageNotFound);

            try
            {
                package.RegisterDeliveryIncident(request.Type, request.Description, request.DateAndTimeOfDeliveryIncident);
            }
            catch (DomainException ex)
            {
                return Result<bool>.ValidationFailure(ex.Error);
            }

            await _unitOfWork.CommitAsync(cancellationToken);

            return Result.Success(true);
        }
    }
}
