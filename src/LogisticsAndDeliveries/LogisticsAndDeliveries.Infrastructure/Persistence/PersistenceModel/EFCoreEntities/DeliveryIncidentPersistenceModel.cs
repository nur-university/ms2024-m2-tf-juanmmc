using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticsAndDeliveries.Infrastructure.Persistence.PersistenceModel.EFCoreEntities
{
    [Table("deliveryIncident")]
    internal class DeliveryIncidentPersistenceModel
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("type")]
        [MaxLength(25)]
        public required string Type { get; set; }

        [Required]
        [Column("description")]
        [MaxLength(500)]
        public required string Description { get; set; }

        [Required]
        [Column("date")]
        public DateTime Date { get; set; }

        [Required]
        [Column("packageId")]
        public Guid PackageId { get; set; }
        public PackagePersistenceModel Package { get; set; }
    }
}
