using LogisticsAndDeliveries.Core.Results;

namespace LogisticsAndDeliveries.Domain.Deliveries
{
    public static class DeliveryErrors
    {
        public static readonly Error InvalidOrderValue = new(
            "Delivery.InvalidOrderValue", 
            "El valor del orden no puede ser cero o negativo.", 
            ErrorType.Failure);

        public static readonly Error InvalidStatusTransition = new(
            "Delivery.InvalidStatusTransition", 
            "La transición de estado no es válida.", 
            ErrorType.Failure);

        public static readonly Error CannotCancelCompletedDelivery = new(
            "Delivery.CannotCancelDelivered", 
            "No se puede cancelar un paquete ya entregado.", 
            ErrorType.Failure);

        public static readonly Error InvalidIncidentDate = new(
            "Delivery.InvalidIncidentDate",
            "No se puede registrar incidente fuera de la fecha de entrega programada.",
            ErrorType.Failure);

        public static readonly Error CannotRegisterIncidentInCurrentStatus = new(
            "Delivery.CannotRegisterIncident",
            "No se puede registrar el incidente a un paquete con estado de entrega diferente a fallido.",
            ErrorType.Failure);

        public static readonly Error DeliveryNotFound = new(
            "Delivery.NotFound",
            "La entrega solicitada no fue encontrada.",
            ErrorType.NotFound);
    }
}
