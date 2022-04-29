using GoxuTour.Domain;
using GoxuTour.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoxuTour.Persistence
{
    public class GoxuTourDbContext : DbContext
    {
        private const string connectionString = "Server=DESKTOP-PF3HH9L\\SQLSERVER2017EXP; Database=GoxuTour; Integrated Security=true;";

        public DbSet<City> Cities { get; set; }
        public DbSet<Station> Stations { get; set; }

        public DbSet<BusManufacturer> busManufacturers { get; set; }

        public DbSet<BusModel> busModels { get; set; }

        public DbSet<Bus> buses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new StationConfiguration());
            modelBuilder.ApplyConfiguration(new BusManufacturerConfiguration());
            modelBuilder.ApplyConfiguration(new BusModelConfiguration());
            modelBuilder.ApplyConfiguration(new BusConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
