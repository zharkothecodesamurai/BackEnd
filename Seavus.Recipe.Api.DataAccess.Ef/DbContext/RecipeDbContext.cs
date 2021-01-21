using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Seavus.Recipe.Api.DataAccess.Ef.EfMapping;
using Seavus.Recipe.Core.Entities;

namespace Seavus.Recipe.Api.DataAccess.Ef.DbContext
{
    public class RecipeDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        private readonly IConfiguration _config;

        public RecipeDbContext(DbContextOptions<RecipeDbContext> options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString = _config.GetConnectionString("RecipeConnection");

            optionsBuilder.UseSqlServer(connString, x => x.MigrationsAssembly("Seavus.Recipe.Api.DataAccess.Ef.Migrations"));

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CountryMapping());
            modelBuilder.ApplyConfiguration(new CityMapping());
            modelBuilder.ApplyConfiguration(new CitizenMapper());
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Citizen> Citizens { get; set; }
    }
}
