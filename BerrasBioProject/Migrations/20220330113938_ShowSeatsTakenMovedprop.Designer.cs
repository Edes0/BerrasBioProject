﻿// <auto-generated />
using System;
using BerrasBioProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BerrasBioProject.Migrations
{
    [DbContext(typeof(BerrasBioProjectContext))]
    [Migration("20220330113938_ShowSeatsTakenMovedprop")]
    partial class ShowSeatsTakenMovedprop
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BerrasBio.Models.Bookings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("NumOfSeats")
                        .HasColumnType("int");

                    b.Property<int>("ShowId")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ShowId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("BerrasBio.Models.Movies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CoverUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("BerrasBio.Models.Salons", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Seats")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Salons");
                });

            modelBuilder.Entity("BerrasBio.Models.Shows", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SalonId")
                        .HasColumnType("int");

                    b.Property<int>("SeatsTaken")
                        .HasColumnType("int");

                    b.Property<DateTime>("ShowTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("SalonId");

                    b.ToTable("Shows");
                });

            modelBuilder.Entity("BerrasBio.Models.Bookings", b =>
                {
                    b.HasOne("BerrasBio.Models.Shows", "Show")
                        .WithMany("Booking")
                        .HasForeignKey("ShowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Show");
                });

            modelBuilder.Entity("BerrasBio.Models.Shows", b =>
                {
                    b.HasOne("BerrasBio.Models.Movies", "Movie")
                        .WithMany("Show")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BerrasBio.Models.Salons", "Salon")
                        .WithMany("Show")
                        .HasForeignKey("SalonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Salon");
                });

            modelBuilder.Entity("BerrasBio.Models.Movies", b =>
                {
                    b.Navigation("Show");
                });

            modelBuilder.Entity("BerrasBio.Models.Salons", b =>
                {
                    b.Navigation("Show");
                });

            modelBuilder.Entity("BerrasBio.Models.Shows", b =>
                {
                    b.Navigation("Booking");
                });
#pragma warning restore 612, 618
        }
    }
}