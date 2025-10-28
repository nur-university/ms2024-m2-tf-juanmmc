using LogisticsAndDeliveries.Core.Abstractions;
using LogisticsAndDeliveries.Core.Results;
using LogisticsAndDeliveries.Domain.Deliveries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsAndDeliveries.Application.Deliveries.SetDeliveryOrder
{
    internal class SetDeliveryOrderHandler : IRequestHandler<SetDeliveryOrderCommand, Result<bool>>
    {
        private readonly IDeliveryRepository _deliveryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SetDeliveryOrderHandler(IDeliveryRepository deliveryRepository, IUnitOfWork unitOfWork)
        {
            _deliveryRepository = deliveryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(SetDeliveryOrderCommand request, CancellationToken cancellationToken)
        {
            var delivery = await _deliveryRepository.GetByIdAsync(request.DeliveryId);
            if (delivery == null)
                return Result<bool>.ValidationFailure(DeliveryErrors.DeliveryNotFound);
            try
            {
                delivery.SetOrder(request.Order);
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
