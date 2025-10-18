using LogisticsAndDeliveries.Domain.Deliveries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsAndDeliveries.Infrastructure.Persistence.DomainModel.Config
{
    internal class DeliveryConfig : IEntityTypeConfiguration<Delivery>
    {
        public void Configure(EntityTypeBuilder<Delivery> builder)
        {
            builder.ToTable("delivery");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id)
                .HasColumnName("id");

            builder.Property(d => d.Name)
                .HasColumnName("name")
                .HasMaxLength(200);

            // PackageAssignments como owned collection
            builder.OwnsMany(d => d.PackageAssignments, pa =>
            {
                pa.WithOwner().HasForeignKey("deliveryId");
                pa.Property<Guid>("id")
                    .HasColumnName("id")
                    .HasDefaultValueSql("gen_random_uuid()")
                    .ValueGeneratedOnAdd(); // Shadow GUID key
                pa.HasKey("id");
                pa.Property(p => p.PackageId).HasColumnName("packageId");
                pa.Property(p => p.ScheduledDate).HasColumnName("scheduledDate");
                pa.ToTable("packageAssignment");
            });

            // DeliveryLocation como owned type (puede ser null)
            builder.OwnsOne(p => p.DeliveryLocation, location =>
            {
                location.Property(l => l.Latitude).HasColumnName("locationLatitude");
                location.Property(l => l.Longitude).HasColumnName("locationLongitude");
                location.Property(l => l.Date).HasColumnName("locationDate");
            });

            // Rutas: relación uno-a-muchos
            builder.HasMany(d => d.Routes)
                .WithOne()
                .HasForeignKey("DeliveryId")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Metadata.FindNavigation(nameof(Delivery.PackageAssignments))
                ?.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Metadata.FindNavigation(nameof(Delivery.Routes))
                ?.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}
