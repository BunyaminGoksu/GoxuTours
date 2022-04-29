using GoxuTour.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoxuTour.Persistence.Configurations
{
    public class BusConfiguration : IEntityTypeConfiguration<Bus>
    {
        public void Configure(EntityTypeBuilder<Bus> builder)
        {
            builder.HasKey(bus =>bus.Id);

            builder.HasOne(bus => bus.BusModel)
                .WithMany(bus=>bus.BusList)
                .HasForeignKey(bus => bus.BusModelId);

            builder.Property(bus => bus.RegistrationPlate)
                .IsRequired()
                .HasColumnType("varchar(50)");
            builder.Property(bus => bus.Year)
                .IsRequired()
                .HasColumnType("smallint");
            builder.Property(bus => bus.SeatMapping)
                .IsRequired();
           
            builder.Property(bus => bus.DistanceTraveled)
                .IsRequired()
                .HasColumnType("int");
            builder.Navigation(bus => bus.BusModel).AutoInclude();

            builder.HasData
                (
                new Bus(1, 2, "34 GRB 22", 1998, SeatingType.Standard, 600),
                new Bus(2, 2, "34 LTF 22", 1999, SeatingType.Premium, 600),
                new Bus(3, 2, "34 KAYA 22", 1997, SeatingType.Deluxe, 600),
                new Bus(4, 2, "34 GKS 22", 1998, SeatingType.Deluxe, 600),
                new Bus(5, 2, "34 UMT 22", 1994, SeatingType.Premium, 600),
                new Bus(6, 2, "34 EMRE 22", 1984, SeatingType.Standard, 600));

        }
    }
}
