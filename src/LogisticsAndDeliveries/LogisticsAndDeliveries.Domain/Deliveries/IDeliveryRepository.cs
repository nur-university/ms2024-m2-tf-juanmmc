using LogisticsAndDeliveries.Core.Abstractions;

namespace LogisticsAndDeliveries.Domain.Deliveries
{
    public interface IDeliveryRepository : IRepository<Delivery>
    {
        Task UpdateAsync(Delivery delivery);
    }
}
