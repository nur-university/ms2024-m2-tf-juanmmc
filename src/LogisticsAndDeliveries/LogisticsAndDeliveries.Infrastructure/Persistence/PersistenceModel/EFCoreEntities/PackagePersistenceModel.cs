using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticsAndDeliveries.Infrastructure.Persistence.PersistenceModel.EFCoreEntities
{
    [Table("package")]
    internal class PackagePersistenceModel
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("identificationNumber")]
        [MaxLength(100)]
        public required string IdentificationNumber { get; set; }

        [Required]
        [Column("scheduledDeliveryDate")]
        public DateTime ScheduledDeliveryDate { get; set; }

        [Required]
        [Column("deliveryId")]
        public Guid DeliveryId { get; set; }

        [Required]
        [Column("patientId")]
        public required string PatientId { get; set; }

        [Required]
        [Column("patientName")]
        [MaxLength(200)]
        public required string PatientName { get; set; }

        [Required]
        [Column("patientEmail")]
        [MaxLength(100)]
        public required string PatientEmail { get; set; }

        [Required]
        [Column("patientPhone")]
        [MaxLength(15)]
        public required string PatientPhone { get; set; }

        [Required]
        [Column("deliveryAddress")]
        [MaxLength(300)]
        public required string DeliveryAddress { get; set; }

        [Required]
        [Column("deliveryLatitude", TypeName = "double precision")]
        public double DeliveryLatitude { get; set; }

        [Required]
        [Column("deliveryLongitude", TypeName = "double precision")]
        public double DeliveryLongitude { get; set; }

        [Required]
        [Column("status")]
        [MaxLength(25)]
        public required string Status { get; set; }

        [Column("evidencePhotoUrl")]
        public string? EvidencePhotoUrl { get; set; }

        [Column("evidenceReceiverName")]
        public string? EvidenceReceiverName { get; set; }

        [Column("evidenceReceiverSignature")]
        public string? EvidenceReceiverSignature { get; set; }

        [Column("evidenceDate")]
        public DateTime? EvidenceDate { get; set; }

        [Column("evidenceObservations")]
        public string? EvidenceObservations { get; set; }

        public required ICollection<DeliveryIncidentPersistenceModel> DeliveryIncidents { get; set; }
    }
}
