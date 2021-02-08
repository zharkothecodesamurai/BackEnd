using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seavus.Recipe.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seavus.Recipe.Api.DataAccess.Ef.EfMapping
{
    public class ShopingListMapping : IEntityTypeConfiguration<ShopingList>
    {
        public void Configure(EntityTypeBuilder<ShopingList> builder)
        {
            builder.ToTable("ShopingLists");
            builder.HasMany(x => x.ShopingListIngredients).WithOne(x => x.ShopingList).HasForeignKey(x => x.ShopingListId);
            
            //builder.HasData(new ShopingList
            //{
            //    Id = 1
            //},
            //new ShopingList
            //{
            //    Id = 2
            //}
            //);
        }

    }
}
