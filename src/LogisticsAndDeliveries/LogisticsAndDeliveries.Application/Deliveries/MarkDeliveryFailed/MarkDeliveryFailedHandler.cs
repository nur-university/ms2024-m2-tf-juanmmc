using LogisticsAndDeliveries.Core.Abstractions;
using LogisticsAndDeliveries.Core.Results;
using LogisticsAndDeliveries.Domain.Deliveries;
using MediatR;

namespace LogisticsAndDeliveries.Application.Deliveries.MarkDeliveryFailed
{
    internal class MarkDeliveryFailedHandler : IRequestHandler<MarkDeliveryFailedCommand, Result<bool>>
    {
        private readonly IDeliveryRepository _deliveryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MarkDeliveryFailedHandler(IDeliveryRepository deliveryRepository, IUnitOfWork unitOfWork)
        {
            _deliveryRepository = deliveryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(MarkDeliveryFailedCommand request, CancellationToken cancellationToken)
        {
            var delivery = await _deliveryRepository.GetByIdAsync(request.DeliveryId);

            if (delivery is null)
            {
                return Result<bool>.ValidationFailure(DeliveryErrors.DeliveryNotFound);
            }

            try
            {
                delivery.MarkFailed();
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
