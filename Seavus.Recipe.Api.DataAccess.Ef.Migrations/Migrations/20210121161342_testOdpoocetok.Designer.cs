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
    [Migration("20210121161342_testOdpoocetok")]
    partial class testOdpoocetok
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

                    b.Property<int>("CityId")
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

                    b.HasIndex("CityId");

                    b.ToTable("Citizens");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 30,
                            CityId = 1,
                            Height = 176,
                            LastName = "Naum",
                            Name = "Zharko"
                        },
                        new
                        {
                            Id = 2,
                            Age = 30,
                            CityId = 1,
                            Height = 156,
                            LastName = "Naum",
                            Name = "Anastazija"
                        },
                        new
                        {
                            Id = 3,
                            Age = 50,
                            CityId = 2,
                            Height = 180,
                            LastName = "Naum",
                            Name = "Bube"
                        },
                        new
                        {
                            Id = 4,
                            Age = 40,
                            CityId = 2,
                            Height = 175,
                            LastName = "Naum",
                            Name = "Dare"
                        },
                        new
                        {
                            Id = 5,
                            Age = 40,
                            CityId = 1,
                            Height = 175,
                            LastName = "Naum",
                            Name = "Cvare"
                        });
                });

            modelBuilder.Entity("Seavus.Recipe.Core.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CityCodeA2")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Population")
                        .HasMaxLength(100)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("City");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityCodeA2 = "SK",
                            CityName = "Skopje",
                            Population = 1000000
                        },
                        new
                        {
                            Id = 2,
                            CityCodeA2 = "BG",
                            CityName = "Beograd",
                            Population = 2000000
                        });
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

            modelBuilder.Entity("Seavus.Recipe.Core.Entities.Citizen", b =>
                {
                    b.HasOne("Seavus.Recipe.Core.Entities.City", "City")
                        .WithMany("Citizens")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("Seavus.Recipe.Core.Entities.City", b =>
                {
                    b.Navigation("Citizens");
                });
#pragma warning restore 612, 618
        }
    }
}
