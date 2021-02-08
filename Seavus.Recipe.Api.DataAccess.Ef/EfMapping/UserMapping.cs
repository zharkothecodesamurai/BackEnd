using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seavus.Recipe.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seavus.Recipe.Api.DataAccess.Ef.EfMapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            //builder.HasKey(x => new { x.Id });
            builder.Property(x => x.FirstName).HasMaxLength(30).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(40).IsRequired();
            builder.Property(x => x.Username).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(40).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(40).IsRequired();
           

            builder.HasOne(x => x.ShopingList).WithOne(x => x.User).HasForeignKey<ShopingList>(x => x.Id);
            builder.HasMany(x => x.Recipes).WithOne(x => x.User).HasForeignKey(x => x.UserId);

            //builder.HasData(new User
            //{
            //    //Id = 1,
            //    FirstName = "Zharko",
            //    LastName = "Naumovski",
            //    Username = "theDisipator",
            //    Email = "test",
            //    Password="test123@@",
               

            //},
            //new User
            //{
            //    //Id = 2,
            //    FirstName = "Anastazija",
            //    LastName = "Naumovski",
            //    Username = "theGangsta",
            //    Email = "test",
            //    Password = "test123@@",
                

            //}
            //);
            
        }
    }
}
