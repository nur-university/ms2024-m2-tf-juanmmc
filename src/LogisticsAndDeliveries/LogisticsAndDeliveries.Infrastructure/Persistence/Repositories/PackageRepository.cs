using LogisticsAndDeliveries.Domain.Packages;
using LogisticsAndDeliveries.Infrastructure.Persistence.DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsAndDeliveries.Infrastructure.Persistence.Repositories
{
    internal class PackageRepository : IPackageRepository
    {
        private readonly DomainDbContext _dbContext;

        public PackageRepository(DomainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Package package)
        {
            await _dbContext.Package.AddAsync(package);
        }

        public async Task<Package?> GetByIdAsync(Guid id, bool readOnly = false)
        {
            // Use the navigation property name 'DeliveryIncidents' in Include instead of the backing field name
            if (readOnly)
            {
                return await _dbContext.Package
                    .AsNoTracking()
                    .FirstOrDefaultAsync(i => i.Id == id);
            }
            else
            {
                return await _dbContext.Package
                    .FirstOrDefaultAsync(i => i.Id == id);
            }
        }

        public Task UpdateAsync(Package package)
        {
            _dbContext.Package.Update(package);
            return Task.CompletedTask;
        }
    }
}
