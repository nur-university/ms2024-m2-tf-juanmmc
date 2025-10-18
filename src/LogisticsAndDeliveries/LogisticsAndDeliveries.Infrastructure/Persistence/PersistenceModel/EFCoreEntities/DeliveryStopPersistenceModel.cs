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
    [Table("deliveryStop")]
    internal class DeliveryStopPersistenceModel
    {
        [Column("id")]
        public Guid Id { get; set; } // Shadow key para EF Core

        [Required]
        [Column("packageId")]
        public Guid PackageId { get; set; }

        [Required]
        [Column("order")]
        public int Order { get; set; }

        [Required]
        [Column("deliveryRouteId")]
        public Guid DeliveryRouteId { get; set; } // Foreign key al DeliveryRoute
        public DeliveryRoutePersistenceModel DeliveryRoute { get; set; } // Navegación inversa
    }
}
