using Microsoft.EntityFrameworkCore;
using Seavus.Recipe.Core.Entities;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Text;

namespace Seavus.Recipe.Api.DataAccess.Ef.EfMapping
{
    class CityMapping : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("City");
            //builder.HasKey(x => new { x.CityCodeA2 });
            builder.Property(x => x.CityCodeA2).HasMaxLength(2).IsRequired();
            builder.Property(x => x.CityName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Population).HasMaxLength(100).IsRequired();

            builder.HasData(new City
            {
                Id = 1,
                CityCodeA2 = "SK",
                CityName="Skopje",
                Population=1000000
            },new City
            {
                Id = 2,
                CityCodeA2 = "BG",
                CityName = "Beograd",
                Population = 2000000
            });
        }
    }
}
