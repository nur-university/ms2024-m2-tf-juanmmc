using LogisticsAndDeliveries.Domain.Deliveries;
using LogisticsAndDeliveries.Domain.Packages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsAndDeliveries.Infrastructure.Persistence.DomainModel
{
    internal class DomainDbContext : DbContext
    {
        public DbSet<Package> Package { get; set; }
        public DbSet<DeliveryIncident> DeliveryIncident { get; set; }
        public DbSet<DeliveryRoute> DeliveryRoute { get; set; }
        public DbSet<Delivery> Delivery { get; set; }

        public DomainDbContext(DbContextOptions<DomainDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<Core.Abstractions.DomainEvent>();
        }
    }
}
