using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seavus.Recipe.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seavus.Recipe.Api.DataAccess.Ef.EfMapping
{
    public class CitizenMapper : IEntityTypeConfiguration<Citizen>
    {
        public void Configure(EntityTypeBuilder<Citizen> builder)
        {
            builder.ToTable("Citizens");
            //builder.HasKey(x => new { x.Id });
            //builder.Property(x=>x.Id)
            builder.Property(x => x.Name).HasMaxLength(20).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Height).HasMaxLength(3).IsRequired();
            builder.Property(x => x.Age).HasMaxLength(3).IsRequired();
            builder.HasOne(x => x.City).WithMany(x => x.Citizens).HasForeignKey(x=>x.CityId);

            builder.HasData
            (
                new Citizen
                {
                    Id = 1,
                    Name = "Zharko",
                    LastName = "Naum",
                    Height = 176,
                    Age = 30,
                    CityId = 1
                },
                new Citizen
                {
                    Id = 2,
                    Name = "Anastazija",
                    LastName = "Naum",
                    Height = 156,
                    Age = 30,
                    CityId = 1
                },
            new Citizen
            {
                Id = 3,
                Name = "Bube",
                LastName = "Naum",
                Height = 180,
                Age = 50,
                CityId=2
            },
            new Citizen
            {
                Id = 4,
                Name = "Dare",
                LastName = "Naum",
                Height = 175,
                Age = 40,
                CityId = 2
            },
            new Citizen
            {
                Id = 5,
                Name = "Cvare",
                LastName = "Naum",
                Height = 175,
                Age = 40,
                CityId = 1
            }
            );


        }
    }
}
