
using Microsoft.EntityFrameworkCore;

namespace ATMSData.Models
{
    public class TrafficAccidentManagementContext : DbContext
    {
        public TrafficAccidentManagementContext(DbContextOptions options):base(options)
        {
            
        }


     
        public DbSet<AccidentRecord> AccidentRecords { get; set; }
        public DbSet<Damage> Damages { get; set; }
        public DbSet<CauseOn> CausesOn { get; set; }
        public DbSet<Factory> Factories { get; set; }
        public DbSet<Injures> Injures { get; set; }
        public DbSet<Occur> Occurs { get; set; }
        public DbSet<Properiety> Properieties { get; set; }
        public DbSet<RoadGeometry> RoadGeometries { get; set; }
        public DbSet<Victim> Victims { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<FactoryAndAccident> Factors { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Involve> Involves { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccidentRecord>()
                .HasKey(x => x.AccidentRecordID);

            modelBuilder.Entity<Factory>()
                .HasKey(x => x.FactorID);

            modelBuilder.Entity<FactoryAndAccident>()
                .HasKey(x => new { x.AccidentRecordId, x.FactoryId });
            modelBuilder.Entity<Occur>()
                .HasKey(x => new { x.AccidentTime, x.AccidentRecordID });

            modelBuilder.Entity<CauseOn>()
              .HasKey(x => new { x.AccidentRecordID, x.VehicleID });
            modelBuilder.Entity<FactoryAndAccident>()
                .HasOne(x => x.AccidentRecords)
                .WithMany(m => m.FactrieAccidents)
                .HasForeignKey(x => x.AccidentRecordId);
            modelBuilder.Entity<FactoryAndAccident>()
                .HasOne(x => x.Factories)
                .WithMany(e => e.AccidentFactries)
                .HasForeignKey(x => x.FactoryId);
            modelBuilder.Entity<Involve>()
                .HasKey(x => new { x.DriverID, x.AccidentRecordID });
            modelBuilder.Entity<Injures>()
               .HasOne(x => x.AccidentRecords)
               .WithMany(m => m.Injures)
               .HasForeignKey(x => x.AccidentRecordID);
            modelBuilder.Entity<Injures>()
                .HasOne(x => x.Victims)
                .WithMany(e => e.Injures)
                .HasForeignKey(x => x.VictimID);
            modelBuilder.Entity<Involve>()
               .HasOne(x => x.AccidentRecords)
               .WithMany(e => e.Involves)
               .HasForeignKey(x => x.AccidentRecordID);
            modelBuilder.Entity<Involve>()
                .HasOne(x => x.Drivers)
                .WithMany(e => e.Involves)
                .HasForeignKey(x => x.DriverID);
            modelBuilder.Entity<Damage>()
               .HasOne(x => x.AccidentRecords)
               .WithMany(m => m.Damages)
               .HasForeignKey(x => x.AccidentRecordID);
            modelBuilder.Entity<Damage>()
                .HasOne(x => x.Properieties)
                .WithMany(e => e.Damages)
                .HasForeignKey(x => x.ProperietyID);
            modelBuilder.Entity<CauseOn>()
               .HasOne(x => x.AccidentRecords)
               .WithMany(m => m.CausesOn)
               .HasForeignKey(x => x.AccidentRecordID);
            modelBuilder.Entity<CauseOn>()
                .HasOne(x => x.Vehicles)
                .WithMany(m => m.CausesOn)
                .HasForeignKey(x => x.VehicleID);

        }
    }
}
