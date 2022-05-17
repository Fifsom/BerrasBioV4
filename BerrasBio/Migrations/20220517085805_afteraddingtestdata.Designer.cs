﻿// <auto-generated />
using System;
using BerrasBio.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BerrasBio.Migrations
{
    [DbContext(typeof(BerrasBioContext))]
    [Migration("20220517085805_afteraddingtestdata")]
    partial class afteraddingtestdata
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BerrasBio.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Movie");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Iron Man 1"
                        },
                        new
                        {
                            Id = 2,
                            Title = "SpiderMan Far From Home"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Cars 1"
                        });
                });

            modelBuilder.Entity("BerrasBio.Models.Salon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumOfSeats")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Salon");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "1",
                            NumOfSeats = 50
                        });
                });

            modelBuilder.Entity("BerrasBio.Models.ShowCase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AvailableSeats")
                        .HasColumnType("int");

                    b.Property<int?>("MovieId")
                        .HasColumnType("int");

                    b.Property<int?>("SalonId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Starts")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("SalonId");

                    b.ToTable("ShowCase");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AvailableSeats = 50,
                            MovieId = 1,
                            SalonId = 1,
                            Starts = new DateTime(2022, 5, 20, 20, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            AvailableSeats = 50,
                            MovieId = 2,
                            SalonId = 1,
                            Starts = new DateTime(2022, 5, 20, 22, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("BerrasBio.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumOfTickets")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("BerrasBio.Models.ShowCase", b =>
                {
                    b.HasOne("BerrasBio.Models.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId");

                    b.HasOne("BerrasBio.Models.Salon", "Salon")
                        .WithMany()
                        .HasForeignKey("SalonId");

                    b.Navigation("Movie");

                    b.Navigation("Salon");
                });
#pragma warning restore 612, 618
        }
    }
}