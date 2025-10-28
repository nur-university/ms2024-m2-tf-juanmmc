using LogisticsAndDeliveries.Core.Abstractions;
using LogisticsAndDeliveries.Core.Results;
using LogisticsAndDeliveries.Domain.Deliveries;
using MediatR;

namespace LogisticsAndDeliveries.Application.Deliveries.MarkDeliveryCompleted
{
    internal class MarkDeliveryCompletedHandler : IRequestHandler<MarkDeliveryCompletedCommand, Result<bool>>
    {
        private readonly IDeliveryRepository _deliveryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MarkDeliveryCompletedHandler(IDeliveryRepository deliveryRepository, IUnitOfWork unitOfWork)
        {
            _deliveryRepository = deliveryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(MarkDeliveryCompletedCommand request, CancellationToken cancellationToken)
        {
            var delivery = await _deliveryRepository.GetByIdAsync(request.DeliveryId);

            if (delivery is null)
            {
                return Result<bool>.ValidationFailure(DeliveryErrors.DeliveryNotFound);
            }

            try
            {
                delivery.MarkCompleted(request.EvidencePhoto);
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
