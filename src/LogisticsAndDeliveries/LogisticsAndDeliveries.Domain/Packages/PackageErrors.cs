using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogisticsAndDeliveries.Core.Results;

namespace LogisticsAndDeliveries.Domain.Packages
{
    public static class PackageErrors
    {
        public static readonly Error InvalidStatusTransition = new(
            "Package.InvalidStatusTransition", 
            "La transición de estado no es válida.", 
            ErrorType.Failure);

        public static readonly Error CannotCancelDeliveredPackage = new(
            "Package.CannotCancelDelivered", 
            "No se puede cancelar un paquete ya entregado.", 
            ErrorType.Failure);

        public static readonly Error InvalidIncidentDate = new(
            "Package.InvalidIncidentDate",
            "No se puede registrar incidente fuera de la fecha de entrega programada.",
            ErrorType.Failure);

        public static readonly Error CannotRegisterIncidentInCurrentStatus = new(
            "Package.CannotRegisterIncident",
            "No se puede registrar el incidente a un paquete con estado de entrega diferente a fallido.",
            ErrorType.Failure);

        public static readonly Error PackageNotFound = new(
            "Package.NotFound",
            "El paquete solicitado no fue encontrado.",
            ErrorType.NotFound);
    }
}
