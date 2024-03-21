﻿// <auto-generated />
using System;
using ArchiveOfWeather.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ArchiveOfWeather.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240321073456_WeatherInfo")]
    partial class WeatherInfo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ArchiveOfWeather.Entities.WeatherInfo", b =>
                {
                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("time");

                    b.Property<double>("AtmosphericPressure")
                        .HasColumnType("float");

                    b.Property<double>("CloudBase")
                        .HasColumnType("float");

                    b.Property<double>("Cloudiness")
                        .HasColumnType("float");

                    b.Property<double>("DewPoint")
                        .HasColumnType("float");

                    b.Property<double>("RelativeHumidity")
                        .HasColumnType("float");

                    b.Property<double>("Temperature")
                        .HasColumnType("float");

                    b.Property<double>("Visibility")
                        .HasColumnType("float");

                    b.Property<string>("WeatherPhenomena")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WindDirection")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("WindSpeed")
                        .HasColumnType("float");

                    b.HasKey("Date", "Time");

                    b.ToTable("WeatherInfo");
                });
#pragma warning restore 612, 618
        }
    }
}