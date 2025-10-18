using LogisticsAndDeliveries.Core.Abstractions;
using System;

namespace LogisticsAndDeliveries.Domain.Packages
{
    public class DeliveryIncident : Entity
    {
        public DeliveryIncidentType Type { get; private set; }
        public string Description { get; private set; }
        public DateTime Date { get; private set; }

        public DeliveryIncident(Guid id, DeliveryIncidentType type, string description, DateTime date) : base(id)
        {
            Type = type;
            Description = description;
            Date = date;
        }
    }
}
