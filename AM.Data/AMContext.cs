﻿using System;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                         Initial Catalog = Airport;
                                         Integrated Security = true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlaneConfig());
        }

    }
}
