using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticsAndDeliveries.Infrastructure.Persistence.PersistenceModel.EFCoreEntities
{
    [Table("delivery")]
    internal class DeliveryPersistenceModel
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("packageId")]
        public required Guid PackageId { get; set; }
        public required PackagePersistenceModel Package { get; set; }

        [Required]
        [Column("driverId")]
        public required Guid DriverId { get; set; }
        public required DriverPersistenceModel Driver { get; set; }

        [Required]
        [Column("scheduledDate", TypeName = "date")]
        public DateOnly ScheduledDate { get; set; }

        [Column("evidencePhoto")]
        public string? EvidencePhoto { get; set; }

        [Column("incidentType")]
        public string? IncidentType { get; set; }

        [Column("incidentDescription")]
        public string? IncidentDescription { get; set; }

        [Required]
        [Column("order", TypeName = "integer")]
        public int Order { get; set; }

        [Required]
        [Column("status")]
        public required string Status { get; set; }

        [Column("updatedAt")]
        public DateTime? UpdatedAt { get; set; }
    }
}
