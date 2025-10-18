using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsAndDeliveries.Infrastructure.Persistence.PersistenceModel.EFCoreEntities
{
    [Owned]
    [Table("packageAssignment")]
    internal class PackageAssignmentPersistenceModel
    {
        [Column("id")]
        public Guid Id { get; set; } // Shadow key para EF Core

        [Required]
        [Column("packageId")]
        public Guid PackageId { get; set; }

        [Required]
        [Column("scheduledDate")]
        public DateTime ScheduledDate { get; set; }

        [Required]
        [Column("deliveryId")]
        public Guid DeliveryId { get; set; } // Foreign key al Delivery
        public DeliveryPersistenceModel Delivery { get; set; } // Navegación inversa
    }
}
