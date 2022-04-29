using GoxuTour.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoxuTour.Persistence.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.HasData
                (
                new City() { Id = 1, Name = "İstanbul" },
                new City() { Id = 2, Name = "Ankara" },
                new City() { Id = 3, Name = "İzmir" },
                new City() { Id = 4, Name = "Antalya" },
                new City() { Id = 5, Name = "Kastamonu" },
                new City() { Id = 6, Name = "Bursa" },
                new City() { Id = 7, Name = "Sakarya" });
        }
    }
}
