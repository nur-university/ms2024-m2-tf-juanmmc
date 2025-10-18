using LogisticsAndDeliveries.Domain.Deliveries;
using LogisticsAndDeliveries.Infrastructure.Persistence.DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            // Use the navigation property name 'PackageAssignments' (not the backing field) in Include
            if (readOnly)
            {
                return await _dbContext.Delivery
                    .AsNoTracking()
                    .Include(d => d.PackageAssignments)
                    .FirstOrDefaultAsync(i => i.Id == id);
            }
            else
            {
                return await _dbContext.Delivery
                    .Include(d => d.PackageAssignments)
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
