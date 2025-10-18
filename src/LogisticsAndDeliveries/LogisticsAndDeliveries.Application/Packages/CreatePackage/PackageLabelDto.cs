using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsAndDeliveries.Application.Packages.CreatePackage
{
    public record PackageLabelDto(
        string IdentificationNumber,
        PatientDataDto PatientData,
        DeliveryAddressDto DeliveryAddress,
        DateTime ScheduledDeliveryDate,
        Guid DeliveryId
    );
}
