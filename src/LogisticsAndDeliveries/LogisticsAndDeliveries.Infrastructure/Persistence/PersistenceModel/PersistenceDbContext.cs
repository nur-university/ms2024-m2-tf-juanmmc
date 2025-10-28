using LogisticsAndDeliveries.Infrastructure.Persistence.PersistenceModel.EFCoreEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsAndDeliveries.Infrastructure.Persistence.PersistenceModel
{
    internal class PersistenceDbContext : DbContext, IDatabase
    {
        public DbSet<PackagePersistenceModel> Package { get; set; }
        public DbSet<DriverPersistenceModel> Driver { get; set; }
        public DbSet<DeliveryPersistenceModel> Delivery { get; set; }
        public PersistenceDbContext(DbContextOptions<PersistenceDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public void Migrate()
        {
            Database.Migrate();
        }
    }
}
