using LogisticsAndDeliveries.Core.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsAndDeliveries.Application.Deliveries.CreateDelivery
{
    public record CreateDeliveryCommand(Guid Id, string Name) : IRequest<Result<Guid>>;
}
