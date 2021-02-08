using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seavus.Recipe.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seavus.Recipe.Api.DataAccess.Ef.EfMapping
{
    public class RecipeMapping : IEntityTypeConfiguration<Core.Entities.RecipeItem>
        
    {
        
        

        public void Configure(EntityTypeBuilder<RecipeItem> builder)
        {
            builder.ToTable("Recipes");
            //builder.HasKey(x => new { x.Label });
            builder.Property(x => x.Label).HasMaxLength(30).IsRequired();
            builder.Property(x => x.Calories).HasMaxLength(40).IsRequired();
            builder.Property(x => x.ImagePath).HasMaxLength(200).IsRequired();

            builder.HasMany(x => x.Ingridients).WithOne(x => x.Recipe).HasForeignKey(x => x.RecipeId);

            //builder.HasData(
            //    new Core.Entities.RecipeItem
            //    {
            //        Id=1,
            //        Label = "Musaka",
            //        Calories=300,
            //        ImagePath="",
            //        UserId=2
            //    },
            //     new Core.Entities.RecipeItem
            //     {
            //         Id = 2,
            //         Label = "AlaZharko",
            //         Calories = 1000,
            //         ImagePath = "",
            //         UserId = 1
            //     },
            //      new Core.Entities.RecipeItem
            //      {
            //          Id = 3,
            //          Label = "NeznamSto",
            //          Calories = 500,
            //          ImagePath = "",
            //          UserId = 2
            //      },
            //       new Core.Entities.RecipeItem
            //       {
            //           Id = 4,
            //           Label = "Tortelini",
            //           Calories = 400,
            //           ImagePath = "",
            //           UserId = 1
            //       }
            //    );

        }
    }
}
