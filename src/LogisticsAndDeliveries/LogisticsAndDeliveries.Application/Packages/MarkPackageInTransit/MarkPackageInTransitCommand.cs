using LogisticsAndDeliveries.Core.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsAndDeliveries.Application.Packages.MarkPackageInTransit
{
    public record MarkPackageInTransitCommand(Guid Id) : IRequest<Result<bool>>;
}
