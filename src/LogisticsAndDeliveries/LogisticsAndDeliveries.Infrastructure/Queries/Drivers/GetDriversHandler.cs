using LogisticsAndDeliveries.Application.Drivers.Dto;
using LogisticsAndDeliveries.Application.Drivers.GetDrivers;
using LogisticsAndDeliveries.Core.Results;
using LogisticsAndDeliveries.Infrastructure.Persistence.PersistenceModel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LogisticsAndDeliveries.Infrastructure.Queries.Drivers
{
    internal class GetDriversHandler : IRequestHandler<GetDriversQuery, Result<ICollection<DriverDto>>>
    {
        private readonly PersistenceDbContext _dbContext;

        public GetDriversHandler(PersistenceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<ICollection<DriverDto>>> Handle(GetDriversQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Driver
                .Select(driver => new DriverDto
                {
                    Id = driver.Id,
                    Name = driver.Name,
                    Latitude = driver.Latitude,
                    Longitude = driver.Longitude,
                    LastLocationUpdate = driver.LastLocationUpdate
                })
                .ToListAsync(cancellationToken);
        }
    }
}
