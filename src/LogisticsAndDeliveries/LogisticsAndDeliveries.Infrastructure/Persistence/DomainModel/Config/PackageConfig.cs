using LogisticsAndDeliveries.Domain.Packages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

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

            // PackageLabel como owned type
            builder.OwnsOne(p => p.PackageLabel, label =>
            {
                label.Property(l => l.IdentificationNumber).HasColumnName("identificationNumber");
                label.Property(l => l.ScheduledDeliveryDate).HasColumnName("scheduledDeliveryDate");
                label.Property(l => l.DeliveryId).HasColumnName("deliveryId");

                // PatientData como owned type anidado
                label.OwnsOne(l => l.PatientData, patient =>
                {
                    patient.Property(pd => pd.PatientId).HasColumnName("patientId");
                    patient.Property(pd => pd.Name).HasColumnName("patientName");
                    patient.Property(pd => pd.Email).HasColumnName("patientEmail");
                    patient.Property(pd => pd.Phone).HasColumnName("patientPhone");
                });

                // DeliveryAddress como owned type anidado
                label.OwnsOne(l => l.DeliveryAddress, address =>
                {
                    address.Property(a => a.Address).HasColumnName("deliveryAddress");
                    address.Property(a => a.Latitude).HasColumnName("deliveryLatitude");
                    address.Property(a => a.Longitude).HasColumnName("deliveryLongitude");
                });
            });

            // EvidenceOfDelivery como owned type (puede ser null)
            builder.OwnsOne(p => p.EvidenceOfDelivery, evidence =>
            {
                evidence.Property(e => e.PhotoUrl).HasColumnName("evidencePhotoUrl");
                evidence.Property(e => e.ReceiverName).HasColumnName("evidenceReceiverName");
                evidence.Property(e => e.ReceiverSignature).HasColumnName("evidenceReceiverSignature");
                evidence.Property(e => e.Date).HasColumnName("evidenceDate");
                evidence.Property(e => e.Observations).HasColumnName("evidenceObservations");
            });

            var statusConverter = new ValueConverter<DeliveryStatus, string>(
                statusEnumValue => statusEnumValue.ToString(),
                status => (DeliveryStatus)Enum.Parse(typeof(DeliveryStatus), status)
            );

            // Status como enum
            builder.Property(p => p.Status)
                .HasConversion(statusConverter)
                .HasColumnName("status");

            builder.HasMany(p => p.DeliveryIncidents)
                .WithOne() // o .WithOne(di => di.Package) si tienes navegación inversa
                .HasForeignKey("packageId") // o el nombre de la columna FK
                .OnDelete(DeleteBehavior.Cascade);

            // DeliveryIncidents como relación (si es colección, usar HasMany y configurar entidad aparte)
            builder.Metadata.FindNavigation(nameof(Package.DeliveryIncidents))
                ?.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}
