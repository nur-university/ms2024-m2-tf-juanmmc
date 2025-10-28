using LogisticsAndDeliveries.Domain.Deliveries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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

            builder.Property(d => d.PackageId)
                .HasColumnName("packageId");

            builder.Property(d => d.DriverId)
                .HasColumnName("driverId");

            builder.Property(d => d.ScheduledDate)
                .HasColumnName("scheduledDate")
                .HasColumnType("date");

            builder.Property(d => d.EvidencePhoto)
                .HasColumnName("evidencePhoto");

            var incidentTypeConverter = new ValueConverter<IncidentType, string>(
                incidentTypeConverter => incidentTypeConverter.ToString(),
                incidentType => (IncidentType)Enum.Parse(typeof(IncidentType), incidentType)
            );

            builder.Property(d => d.IncidentType)
                .HasConversion(incidentTypeConverter)
                .HasColumnName("incidentType");

            builder.Property(d => d.IncidentDescription)
                .HasColumnName("incidentDescription");

            builder.Property(d => d.Order)
                .HasColumnName("order")
                .HasColumnType("integer");

            var statusConverter = new ValueConverter<DeliveryStatus, string>(
                statusConverter => statusConverter.ToString(),
                status => (DeliveryStatus)Enum.Parse(typeof(DeliveryStatus), status)
            );

            builder.Property(d => d.Status)
                .HasConversion(statusConverter)
                .HasColumnName("status");

            builder.Property(d => d.UpdatedAt)
                .HasColumnName("updatedAt");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}
