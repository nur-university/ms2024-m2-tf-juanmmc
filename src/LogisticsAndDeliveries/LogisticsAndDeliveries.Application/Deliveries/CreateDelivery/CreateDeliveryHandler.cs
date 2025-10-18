using LogisticsAndDeliveries.Core.Abstractions;
using LogisticsAndDeliveries.Core.Results;
using LogisticsAndDeliveries.Domain.Deliveries;
using LogisticsAndDeliveries.Domain.Packages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsAndDeliveries.Application.Deliveries.CreateDelivery
{
    internal class CreateDeliveryHandler : IRequestHandler<CreateDeliveryCommand, Result<Guid>>
    {
        private readonly IDeliveryRepository _deliveryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateDeliveryHandler(IDeliveryRepository deliveryRepository, IUnitOfWork unitOfWork)
        {
            _deliveryRepository = deliveryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(CreateDeliveryCommand request, CancellationToken cancellationToken)
        {
            // Crear el agregado de dominio
            var delivery = new Delivery(request.Id, request.Name);

            // Persistir el agregado
            await _deliveryRepository.AddAsync(delivery);
            await _unitOfWork.CommitAsync(cancellationToken);

            return Result.Success(delivery.Id);
        }
    }
}
