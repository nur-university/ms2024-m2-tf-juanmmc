using LogisticsAndDeliveries.Domain.Packages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LogisticsAndDeliveries.Infrastructure.Persistence.DomainModel.Config
{
    internal class PackageConfig : IEntityTypeConfiguration<Package>
    {
        public void Configure(EntityTypeBuilder<Package> builder)
        {
            builder.ToTable("package");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id");

            builder.Property(p => p.Number)
                .HasColumnName("number")
                .HasMaxLength(100);

            builder.Property(p => p.PatientId)
                .HasColumnName("patientId");

            builder.Property(p => p.PatientName)
                .HasColumnName("patientName")
                .HasMaxLength(200);

            builder.Property(p => p.PatientPhone)
                .HasColumnName("patientPhone")
                .HasMaxLength(15);

            builder.Property(p => p.DeliveryAddress)
                .HasColumnName("deliveryAddress")
                .HasMaxLength(300);

            builder.Property(p => p.DeliveryLatitude)
                .HasColumnName("deliveryLatitude")
                .HasColumnType("double precision");

            builder.Property(p => p.DeliveryLongitude)
                .HasColumnName("deliveryLongitude")
                .HasColumnType("double precision");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}
