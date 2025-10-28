using LogisticsAndDeliveries.Core.Abstractions;
using LogisticsAndDeliveries.Core.Results;
using LogisticsAndDeliveries.Domain.Deliveries;
using MediatR;

namespace LogisticsAndDeliveries.Application.Deliveries.RegisterDeliveryIncident
{
    internal class RegisterDeliveryIncidentHandler : IRequestHandler<RegisterDeliveryIncidentCommand, Result<bool>>
    {
        private readonly IDeliveryRepository _deliveryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterDeliveryIncidentHandler(IDeliveryRepository deliveryRepository, IUnitOfWork unitOfWork)
        {
            _deliveryRepository = deliveryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(RegisterDeliveryIncidentCommand request, CancellationToken cancellationToken)
        {
            var delivery = await _deliveryRepository.GetByIdAsync(request.DeliveryId);

            if (delivery == null)
                return Result<bool>.ValidationFailure(DeliveryErrors.DeliveryNotFound);

            try
            {
                delivery.RegisterDeliveryIncident(request.IncidentType, request.IncidentDescription);
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
