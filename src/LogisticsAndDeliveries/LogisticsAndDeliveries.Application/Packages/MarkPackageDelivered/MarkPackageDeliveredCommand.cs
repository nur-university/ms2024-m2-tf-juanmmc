using LogisticsAndDeliveries.Core.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsAndDeliveries.Application.Packages.MarkPackageDelivered
{
    public record MarkPackageDeliveredCommand(
        Guid Id,
        string PhotoUrl,
        string ReceiverName,
        string ReceiverSignature,
        DateTime Date,
        string Observations
    ) : IRequest<Result<bool>>;
}
