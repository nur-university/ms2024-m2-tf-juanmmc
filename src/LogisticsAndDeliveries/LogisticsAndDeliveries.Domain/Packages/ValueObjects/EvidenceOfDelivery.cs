using System;

namespace LogisticsAndDeliveries.Domain.Packages.ValueObjects
{
    public record EvidenceOfDelivery(
        string PhotoUrl,
        string ReceiverName,
        string ReceiverSignature,
        DateTime Date,
        string Observations
    );
}