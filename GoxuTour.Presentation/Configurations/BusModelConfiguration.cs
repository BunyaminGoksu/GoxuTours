using GoxuTour.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoxuTour.Persistence.Configurations
{
	public class BusModelConfiguration : IEntityTypeConfiguration<BusModel>
	{
		public void Configure(EntityTypeBuilder<BusModel> builder)
		{
			builder.HasKey(bm => bm.Id);

			builder.Property(bm => bm.Name)
				.IsRequired()
				.HasColumnType("varchar(50)");

			builder.HasOne(bm => bm.BusManufacturer)
				.WithMany()
				.HasForeignKey(bm => bm.BusManufacturerId);

			builder.Property(bm => bm.Type)
				.IsRequired();

			builder.Property(bm => bm.SeatCapacity)
				.IsRequired()
				.HasColumnType("int");

			builder.Property(bm => bm.HasToilet)
				.IsRequired();
			builder.Ignore(bm => bm.SeatTemplate);
			
			builder.HasData
			   (new BusModel(1, "Travego", 1, Bustype.Coach, 44, true),
				new BusModel(2, "Neoplan", 2, Bustype.Coach, 44, true),
				new BusModel(3, "Connecto", 3, Bustype.Coach, 44, false),
				new BusModel(4, "Travego", 4, Bustype.Coach, 44, true),
				new BusModel(5, "Travego", 5, Bustype.Coach, 44, false));
		}
	}
}
