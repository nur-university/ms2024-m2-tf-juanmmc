using LogisticsAndDeliveries.Application.Deliveries.Dto;
using LogisticsAndDeliveries.Application.Deliveries.GetDeliveries;
using LogisticsAndDeliveries.Core.Results;
using LogisticsAndDeliveries.Infrastructure.Persistence.PersistenceModel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LogisticsAndDeliveries.Infrastructure.Queries.Deliveries
{
    internal class GetDeliveriesByOrderHandler : IRequestHandler<GetDeliveriesByOrderQuery, Result<ICollection<DeliveryDto>>>
    {
        private readonly PersistenceDbContext _dbContext;

        public GetDeliveriesByOrderHandler(PersistenceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<ICollection<DeliveryDto>>> Handle(GetDeliveriesByOrderQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Delivery
                .Where(delivery => delivery.DriverId == request.DriverId && delivery.ScheduledDate == request.ScheduledDate)
                .OrderBy(delivery => delivery.Order)
                .Select(delivery => new DeliveryDto
                {
                    Id = delivery.Id,
                    PackageId = delivery.PackageId,
                    DriverId = delivery.DriverId,
                    ScheduledDate = delivery.ScheduledDate,
                    EvidencePhoto = delivery.EvidencePhoto,
                    IncidentType = delivery.IncidentType,
                    IncidentDescription = delivery.IncidentDescription,
                    Order = delivery.Order,
                    Status = delivery.Status,
                    UpdatedAt = delivery.UpdatedAt
                })
                .ToListAsync(cancellationToken);
        }
    }
}
