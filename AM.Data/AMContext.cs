using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.Core.Domain;
using AM.Data.configuration;
using Microsoft.EntityFrameworkCore;

namespace AM.Data
{
    public class AMContext : DbContext
    {
        public DbSet<Flight>  Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Traveller> Travellers { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                         Initial Catalog = Airport;
                                         Integrated Security = true");
             
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlaneConfig());
            modelBuilder.ApplyConfiguration(new FlightPlaneConfig());
            modelBuilder.ApplyConfiguration(new PassengerConfig());
            modelBuilder.ApplyConfiguration(new ReservationConfiguration());
            /* 
              ** questions 3&4 de Stratégies d’héritage**
            modelBuilder.ApplyConfiguration(new TravellerConfig());
            modelBuilder.ApplyConfiguration(new StaffConfig());
            */

            // ⬆ or ⬇
            /* modelBuilder.Entity<Flight>()
                        .HasMany(f => f.Passengers)
                        .WithMany(p => p.Flights)
                        .UsingEntity(jointure => jointure.ToTable("FP"))
                        .HasOne(f => f.MyPlane)
                        .WithMany(p => p.Flights)
                        .HasForeignKey(f => f.PlaneId)
                        .OnDelete(DeleteBehavior.SetNull);
            */
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>()
                                .HaveColumnType("date");
        }



    }
}
