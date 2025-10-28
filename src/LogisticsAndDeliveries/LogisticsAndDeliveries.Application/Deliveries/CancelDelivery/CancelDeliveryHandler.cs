using LogisticsAndDeliveries.Core.Abstractions;
using LogisticsAndDeliveries.Core.Results;
using LogisticsAndDeliveries.Domain.Deliveries;
using MediatR;

namespace LogisticsAndDeliveries.Application.Deliveries.CancelDelivery
{
    internal class CancelDeliveryHandler : IRequestHandler<CancelDeliveryCommand, Result<bool>>
    {
        private readonly IDeliveryRepository _deliveryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CancelDeliveryHandler(IDeliveryRepository deliveryRepository, IUnitOfWork unitOfWork)
        {
            _deliveryRepository = deliveryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(CancelDeliveryCommand request, CancellationToken cancellationToken)
        {
            var delivery = await _deliveryRepository.GetByIdAsync(request.DeliveryId);

            if (delivery is null)
            {
                return Result<bool>.ValidationFailure(DeliveryErrors.DeliveryNotFound);
            }

            try
            {
                delivery.Cancel();
            }
            catch (DomainException ex)
            {
                return Result<bool>.ValidationFailure(ex.Error);
            }

            await _unitOfWork.CommitAsync(cancellationToken);

            return true;
        }
    }
}
