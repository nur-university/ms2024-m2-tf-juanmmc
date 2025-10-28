using LogisticsAndDeliveries.Core.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsAndDeliveries.Domain.Drivers
{
    public static class DriverErrors
    {
        public static readonly Error DriverNotFound = new(
            "Driver.NotFound",
            "The requested driver was not found.",
            ErrorType.NotFound);
    }
}
