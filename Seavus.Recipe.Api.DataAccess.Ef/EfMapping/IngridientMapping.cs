using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seavus.Recipe.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seavus.Recipe.Api.DataAccess.Ef.EfMapping
{
    public class IngridientMapping : IEntityTypeConfiguration<Ingridient>
    {
        public void Configure(EntityTypeBuilder<Ingridient> builder)
        {
            builder.ToTable("Ingridients");
            builder.Property(x => x.Text).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Weight).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Image).HasMaxLength(200);

            builder.HasMany(x => x.ShopingListIngredients).WithOne(x => x.Ingridient).HasForeignKey(x => x.IngridientsId);
            //builder.HasData(
            //    new Ingridient
            //    {
            //        Id=1,
            //        Text="Kompir",
            //        Weight=1000,
            //        Image="",
            //        ShopingListId=2,
            //        RecipeId=1
            //    },
            //     new Ingridient
            //     {
            //         Id = 2,
            //         Text = "Meleno Meso",
            //         Weight = 1000,
            //         Image = "",
            //         ShopingListId = 2,
            //         RecipeId = 1
            //     },
            //      new Ingridient
            //      {
            //          Id = 3,
            //          Text = "Pecurki",
            //          Weight = 1000,
            //          Image = "",
            //          ShopingListId = 1,
            //          RecipeId = 2
            //      },
            //      new Ingridient
            //      {
            //          Id = 4,
            //          Text = "Kashkaval",
            //          Weight = 200,
            //          Image = "",
            //          ShopingListId = 1,
            //          RecipeId = 2
            //      },
            //       new Ingridient
            //       {
            //           Id = 5,
            //           Text = "salama",
            //           Weight = 200,
            //           Image = "",
            //           ShopingListId = 2,
            //           RecipeId = 3
            //       },
            //        new Ingridient
            //        {
            //            Id = 6,
            //            Text = "maslinki",
            //            Weight = 500,
            //            Image = "",
            //            ShopingListId = 2,
            //            RecipeId = 3
            //        },
            //        new Ingridient
            //        {
            //            Id = 7,
            //            Text = "tortelini",
            //            Weight = 1000,
            //            Image = "",
            //            ShopingListId = 1,
            //            RecipeId = 4
            //        },
            //        new Ingridient
            //        {
            //            Id = 8,
            //            Text = "Kashkaval",
            //            Weight = 300,
            //            Image = "",
            //            ShopingListId = 1,
            //            RecipeId = 4
            //        },
            //         new Ingridient
            //         {
            //             Id = 9,
            //             Text = "Mleko",
            //             Weight = 300,
            //             Image = "",
            //             ShopingListId = 1,
            //             RecipeId = 3
            //         }
            //    ) ;

           
        }
    }
}
