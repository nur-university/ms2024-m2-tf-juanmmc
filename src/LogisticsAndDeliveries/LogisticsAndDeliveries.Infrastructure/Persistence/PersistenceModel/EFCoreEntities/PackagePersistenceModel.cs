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
        [Column("number")]
        [MaxLength(100)]
        public required string Number { get; set; }

        [Required]
        [Column("patientId")]
        public required Guid PatientId { get; set; }

        [Required]
        [Column("patientName")]
        [MaxLength(200)]
        public required string PatientName { get; set; }

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
    }
}
