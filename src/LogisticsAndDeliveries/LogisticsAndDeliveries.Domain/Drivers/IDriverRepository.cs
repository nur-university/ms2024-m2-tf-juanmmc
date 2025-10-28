using LogisticsAndDeliveries.Core.Abstractions;

namespace LogisticsAndDeliveries.Domain.Drivers
{
    public interface IDriverRepository : IRepository<Driver>
    {
        Task UpdateAsync(Driver driver);
    }
}
