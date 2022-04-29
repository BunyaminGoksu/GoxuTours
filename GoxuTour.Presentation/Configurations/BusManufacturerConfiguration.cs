using GoxuTour.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoxuTour.Persistence.Configurations
{
    public class BusManufacturerConfiguration : IEntityTypeConfiguration<BusManufacturer>
    {
        public void Configure(EntityTypeBuilder<BusManufacturer> builder)
        {
            builder.HasKey(bus => bus.Id);
            builder.Property(bus => bus.Name)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.HasData(
                new BusManufacturer(1, "Mercedes"),
                new BusManufacturer(2, "Wolksvagen"),
                new BusManufacturer(3, "BMW"),
                new BusManufacturer(4, "FIAT"),
                new BusManufacturer(5, "MAN")
                );


        }
    }
}
