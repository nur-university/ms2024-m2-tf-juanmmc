using LogisticsAndDeliveries.Core.Abstractions;
using LogisticsAndDeliveries.Core.Results;
using LogisticsAndDeliveries.Domain.Packages;
using LogisticsAndDeliveries.Domain.Packages.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsAndDeliveries.Application.Packages.CreatePackages
{
    internal class CreatePackageHandler : IRequestHandler<CreatePackageCommand, Result<Guid>>
    {
        private readonly IPackageRepository _packageRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePackageHandler(IPackageRepository packageRepository, IUnitOfWork unitOfWork)
        {
            _packageRepository = packageRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(CreatePackageCommand request, CancellationToken cancellationToken)
        {
            // Mapear DTOs a objetos de valor del dominio
            var packageLabel = new PackageLabel(
                request.PackageLabel.IdentificationNumber,
                request.PackageLabel.ScheduledDeliveryDate,
                request.PackageLabel.DeliveryId,
                new PatientData(
                    request.PackageLabel.PatientData.PatientId,
                    request.PackageLabel.PatientData.Name,
                    request.PackageLabel.PatientData.Email,
                    request.PackageLabel.PatientData.Phone),
                new DeliveryAddress(
                    request.PackageLabel.DeliveryAddress.Address,
                    request.PackageLabel.DeliveryAddress.Latitude,
                    request.PackageLabel.DeliveryAddress.Longitude)
            );

            // Crear el agregado de dominio
            var package = new Package(request.Id, packageLabel);

            // Persistir el agregado
            await _packageRepository.AddAsync(package);
            await _unitOfWork.CommitAsync(cancellationToken);

            return Result.Success(package.Id);
        }
    }
}
