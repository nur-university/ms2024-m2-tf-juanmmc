using LogisticsAndDeliveries.Domain.Drivers;
using LogisticsAndDeliveries.Infrastructure.Persistence.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace LogisticsAndDeliveries.Infrastructure.Persistence.Repositories
{
    internal class DriverRepository : IDriverRepository
    {
        private readonly DomainDbContext _dbContext;

        public DriverRepository(DomainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Driver driver)
        {
            await _dbContext.Driver.AddAsync(driver);
        }

        public async Task<Driver?> GetByIdAsync(Guid id, bool readOnly = false)
        {
            if (readOnly)
            {
                return await _dbContext.Driver
                    .AsNoTracking()
                    .FirstOrDefaultAsync(i => i.Id == id);
            }
            else
            {
                return await _dbContext.Driver
                    .FirstOrDefaultAsync(i => i.Id == id);
            }
        }

        public Task UpdateAsync(Driver driver)
        {
            _dbContext.Driver.Update(driver);
            return Task.CompletedTask;
        }
    }
}
