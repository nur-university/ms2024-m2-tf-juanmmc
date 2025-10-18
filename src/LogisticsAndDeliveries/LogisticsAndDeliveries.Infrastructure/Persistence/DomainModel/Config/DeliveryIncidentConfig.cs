using LogisticsAndDeliveries.Domain.Packages;
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
    internal class DeliveryIncidentConfig : IEntityTypeConfiguration<DeliveryIncident>
    {
        public void Configure(EntityTypeBuilder<DeliveryIncident> builder)
        {
            builder.ToTable("deliveryIncident");

            builder.HasKey(di => di.Id);

            builder.Property(di => di.Id)
                .HasColumnName("id");

            var typeConverter = new ValueConverter<DeliveryIncidentType, string>(
                typeConverter => typeConverter.ToString(),
                type => (DeliveryIncidentType)Enum.Parse(typeof(DeliveryIncidentType), type)
            );

            builder.Property(di => di.Type)
                .HasConversion(typeConverter)
                .HasColumnName("type");

            builder.Property(di => di.Description)
                .HasMaxLength(500)
                .HasColumnName("description");

            builder.Property(di => di.Date)
                .HasColumnName("date");

            // Clave foránea a Package
            builder.Property<Guid>("packageId");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}
