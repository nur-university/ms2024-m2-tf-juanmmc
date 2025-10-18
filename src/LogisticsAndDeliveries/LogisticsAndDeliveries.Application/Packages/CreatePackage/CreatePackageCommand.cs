using LogisticsAndDeliveries.Application.Packages.CreatePackage;
using LogisticsAndDeliveries.Core.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsAndDeliveries.Application.Packages.CreatePackages
{
    public record CreatePackageCommand(Guid Id, PackageLabelDto PackageLabel) : IRequest<Result<Guid>>;
}
