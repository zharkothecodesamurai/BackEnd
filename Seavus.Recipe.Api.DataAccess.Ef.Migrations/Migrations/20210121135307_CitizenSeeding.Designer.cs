﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Seavus.Recipe.Api.DataAccess.Ef.DbContext;

namespace Seavus.Recipe.Api.DataAccess.Ef.Migrations.Migrations
{
    [DbContext(typeof(RecipeDbContext))]
    [Migration("20210121135307_CitizenSeeding")]
    partial class CitizenSeeding
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Seavus.Recipe.Core.Entities.Citizen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Age")
                        .HasMaxLength(3)
                        .HasColumnType("int");

                    b.Property<int>("Height")
                        .HasMaxLength(3)
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Citizens");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 30,
                            Height = 176,
                            LastName = "Naum",
                            Name = "Zharko"
                        });
                });

            modelBuilder.Entity("Seavus.Recipe.Core.Entities.City", b =>
                {
                    b.Property<string>("CityCodeA2")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Population")
                        .HasMaxLength(100)
                        .HasColumnType("int");

                    b.HasKey("CityCodeA2");

                    b.ToTable("City");
                });

            modelBuilder.Entity("Seavus.Recipe.Core.Entities.Country", b =>
                {
                    b.Property<string>("CountryCodeA2")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("CountryName")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("CountryCodeA2", "CountryName");

                    b.ToTable("Country");
                });
#pragma warning restore 612, 618
        }
    }
}
