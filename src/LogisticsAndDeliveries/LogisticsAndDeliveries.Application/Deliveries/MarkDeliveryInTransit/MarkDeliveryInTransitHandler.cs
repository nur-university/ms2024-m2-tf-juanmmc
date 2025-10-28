using LogisticsAndDeliveries.Core.Abstractions;
using LogisticsAndDeliveries.Core.Results;
using LogisticsAndDeliveries.Domain.Deliveries;
using MediatR;

namespace LogisticsAndDeliveries.Application.Deliveries.MarkDeliveryInTransit
{
    internal class MarkDeliveryInTransitHandler : IRequestHandler<MarkDeliveryInTransitCommand, Result<bool>>
    {
        private readonly IDeliveryRepository _deliveryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MarkDeliveryInTransitHandler(IDeliveryRepository deliveryRepository, IUnitOfWork unitOfWork)
        {
            _deliveryRepository = deliveryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(MarkDeliveryInTransitCommand request, CancellationToken cancellationToken)
        {
            var delivery = await _deliveryRepository.GetByIdAsync(request.DeliveryId);

            if (delivery is null)
            {
                return Result<bool>.ValidationFailure(DeliveryErrors.DeliveryNotFound);
            }

            try
            {
                delivery.MarkInTransit();
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
