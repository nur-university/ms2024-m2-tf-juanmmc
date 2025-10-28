using LogisticsAndDeliveries.Domain.Deliveries;
using LogisticsAndDeliveries.Infrastructure.Persistence.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace LogisticsAndDeliveries.Infrastructure.Persistence.Repositories
{
    internal class DeliveryRepository : IDeliveryRepository
    {
        private readonly DomainDbContext _dbContext;

        public DeliveryRepository(DomainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Delivery delivery)
        {
            await _dbContext.Delivery.AddAsync(delivery);
        }

        public async Task<Delivery?> GetByIdAsync(Guid id, bool readOnly = false)
        {
            if (readOnly)
            {
                return await _dbContext.Delivery
                    .AsNoTracking()
                    .FirstOrDefaultAsync(i => i.Id == id);
            }
            else
            {
                return await _dbContext.Delivery
                    .FirstOrDefaultAsync(i => i.Id == id);
            }
        }

        public Task UpdateAsync(Delivery delivery)
        {
            _dbContext.Delivery.Update(delivery);
            return Task.CompletedTask;
        }
    }
}
