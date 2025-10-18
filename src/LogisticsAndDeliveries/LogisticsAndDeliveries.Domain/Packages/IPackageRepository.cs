using LogisticsAndDeliveries.Core.Abstractions;

namespace LogisticsAndDeliveries.Domain.Packages
{
    public interface IPackageRepository : IRepository<Package>
    {
        Task UpdateAsync(Package package);
    }
}
