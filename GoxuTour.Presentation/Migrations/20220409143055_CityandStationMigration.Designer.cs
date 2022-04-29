﻿// <auto-generated />
using GoxuTour.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GoxuTour.Persistence.Migrations
{
    [DbContext(typeof(GoxuTourDbContext))]
    [Migration("20220409143055_CityandStationMigration")]
    partial class CityandStationMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GoxuTour.Domain.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "İstanbul"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Ankara"
                        },
                        new
                        {
                            Id = 3,
                            Name = "İzmir"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Antalya"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Kastamonu"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Bursa"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Sakarya"
                        });
                });

            modelBuilder.Entity("GoxuTour.Domain.Station", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Stations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityId = 1,
                            Name = "Büyük İstanbul Otogari"
                        },
                        new
                        {
                            Id = 2,
                            CityId = 1,
                            Name = "Alibeyköy"
                        },
                        new
                        {
                            Id = 3,
                            CityId = 2,
                            Name = "Aşti"
                        },
                        new
                        {
                            Id = 4,
                            CityId = 3,
                            Name = "Terminal"
                        },
                        new
                        {
                            Id = 5,
                            CityId = 4,
                            Name = "Terminal"
                        },
                        new
                        {
                            Id = 6,
                            CityId = 5,
                            Name = "Terminal"
                        });
                });

            modelBuilder.Entity("GoxuTour.Domain.Station", b =>
                {
                    b.HasOne("GoxuTour.Domain.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });
#pragma warning restore 612, 618
        }
    }
}
