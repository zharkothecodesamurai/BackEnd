using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seavus.Recipe.Core.Entities;

namespace Seavus.Recipe.Api.DataAccess.Ef.EfMapping
{
    public class CountryMapping : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Country");
            builder.HasKey(x => new { x.CountryCodeA2, x.CountryName });
            builder.Property(x => x.CountryCodeA2).HasMaxLength(2).IsRequired();
            builder.Property(x => x.CountryName).HasMaxLength(250).IsRequired();
        }
    }
}
