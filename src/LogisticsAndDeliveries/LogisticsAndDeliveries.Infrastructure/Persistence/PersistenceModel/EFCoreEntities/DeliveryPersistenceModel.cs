using System;
using System.Collections.Generic;
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

        [Column("name")]
        [MaxLength(200)]
        [Required]
        public required string Name { get; set; }

        [Column("locationLatitude", TypeName = "double precision")]
        public double? LocationLatitude { get; set; }

        [Column("locationLongitude", TypeName = "double precision")]
        public double? LocationLongitude { get; set; }

        [Column("locationDate")]
        public DateTime? LocationDate { get; set; }

        public required ICollection<PackageAssignmentPersistenceModel> PackageAssignments { get; set; }
        public required ICollection<DeliveryRoutePersistenceModel> DeliveryRoutes { get; set; }
    }
}
