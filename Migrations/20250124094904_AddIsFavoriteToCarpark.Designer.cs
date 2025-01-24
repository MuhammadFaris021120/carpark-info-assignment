﻿// <auto-generated />
using CarparkInfo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarparkInfo.Migrations
{
    [DbContext(typeof(CarparkDbContext))]
    [Migration("20250124094904_AddIsFavoriteToCarpark")]
    partial class AddIsFavoriteToCarpark
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.1");

            modelBuilder.Entity("CarparkInfo.Models.Carpark", b =>
                {
                    b.Property<string>("car_park_no")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsFavorite")
                        .HasColumnType("INTEGER");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("car_park_basement")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("car_park_decks")
                        .HasColumnType("INTEGER");

                    b.Property<string>("car_park_type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("free_parking")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("gantry_height")
                        .HasColumnType("REAL");

                    b.Property<string>("night_parking")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("short_term_parking")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("type_of_parking_system")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("x_coord")
                        .HasColumnType("REAL");

                    b.Property<double>("y_coord")
                        .HasColumnType("REAL");

                    b.HasKey("car_park_no");

                    b.ToTable("Carparks");
                });
#pragma warning restore 612, 618
        }
    }
}