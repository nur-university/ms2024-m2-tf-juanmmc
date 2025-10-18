namespace LogisticsAndDeliveries.Domain.Packages.ValueObjects
{
    public record PatientData(
        string PatientId,
        string Name,
        string Email,
        string Phone
    );
}