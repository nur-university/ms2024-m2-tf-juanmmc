using LogisticsAndDeliveries.Core.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsAndDeliveries.Application.Deliveries.SetDeliveryOrder
{
    public record SetDeliveryOrderCommand(Guid DeliveryId, int Order) : IRequest<Result<bool>>;
}
