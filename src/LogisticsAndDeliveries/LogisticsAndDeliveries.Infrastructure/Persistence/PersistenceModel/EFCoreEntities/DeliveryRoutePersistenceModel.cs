using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticsAndDeliveries.Infrastructure.Persistence.PersistenceModel.EFCoreEntities
{
    [Table("deliveryRoute")]
    internal class DeliveryRoutePersistenceModel
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("scheduledDate")]
        public DateTime ScheduledDate { get; set; }

        [Required]
        [Column("status")]
        public int Status { get; set; }

        [Required]
        [Column("deliveryId")]
        public Guid DeliveryId { get; set; }
        public DeliveryPersistenceModel Delivery { get; set; }

        public required ICollection<DeliveryStopPersistenceModel> DeliveryStops { get; set; }
    }
}
