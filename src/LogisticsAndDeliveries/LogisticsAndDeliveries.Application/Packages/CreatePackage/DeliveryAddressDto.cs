using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsAndDeliveries.Application.Packages.CreatePackage
{
    public record DeliveryAddressDto(
        string Address,
        double Latitude,
        double Longitude
    );
}
