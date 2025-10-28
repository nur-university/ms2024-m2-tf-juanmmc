using LogisticsAndDeliveries.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsAndDeliveries.Domain.Deliveries
{
    public interface IDeliveryRepository : IRepository<Delivery>
    {
        Task UpdateAsync(Delivery delivery);
        //Task<Delivery> GetByPackageAndDriverAsync(Guid packageId, Guid driverId);

        // Lista entregas por repartidor y fecha programada
        // Task<IEnumerable<Delivery>> ListByDriverAndDateAsync(Guid driverId, DateOnly scheduledDate);
    }
}
