﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Seavus.Recipe.Api.DataAccess.Ef.DbContext;

namespace Seavus.Recipe.Api.DataAccess.Ef.Migrations.Migrations
{
    [DbContext(typeof(RecipeDbContext))]
    [Migration("20210205105654_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Seavus.Recipe.Core.Entities.Ingridient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Image")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid>("RecipeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Weight")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("Ingridients");
                });

            modelBuilder.Entity("Seavus.Recipe.Core.Entities.RecipeItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Calories")
                        .HasMaxLength(40)
                        .HasColumnType("real");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("Seavus.Recipe.Core.Entities.ShopingList", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("ShopingLists");
                });

            modelBuilder.Entity("Seavus.Recipe.Core.Entities.ShopingListIngredients", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<Guid>("IngridientsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ShopingListId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IngridientsId");

                    b.HasIndex("ShopingListId");

                    b.ToTable("ShopingListIngredients");
                });

            modelBuilder.Entity("Seavus.Recipe.Core.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Seavus.Recipe.Core.Entities.Ingridient", b =>
                {
                    b.HasOne("Seavus.Recipe.Core.Entities.RecipeItem", "Recipe")
                        .WithMany("Ingridients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("Seavus.Recipe.Core.Entities.RecipeItem", b =>
                {
                    b.HasOne("Seavus.Recipe.Core.Entities.User", "User")
                        .WithMany("Recipes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Seavus.Recipe.Core.Entities.ShopingList", b =>
                {
                    b.HasOne("Seavus.Recipe.Core.Entities.User", "User")
                        .WithOne("ShopingList")
                        .HasForeignKey("Seavus.Recipe.Core.Entities.ShopingList", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Seavus.Recipe.Core.Entities.ShopingListIngredients", b =>
                {
                    b.HasOne("Seavus.Recipe.Core.Entities.Ingridient", "Ingridient")
                        .WithMany("ShopingListIngredients")
                        .HasForeignKey("IngridientsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Seavus.Recipe.Core.Entities.ShopingList", "ShopingList")
                        .WithMany("ShopingListIngredients")
                        .HasForeignKey("ShopingListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingridient");

                    b.Navigation("ShopingList");
                });

            modelBuilder.Entity("Seavus.Recipe.Core.Entities.Ingridient", b =>
                {
                    b.Navigation("ShopingListIngredients");
                });

            modelBuilder.Entity("Seavus.Recipe.Core.Entities.RecipeItem", b =>
                {
                    b.Navigation("Ingridients");
                });

            modelBuilder.Entity("Seavus.Recipe.Core.Entities.ShopingList", b =>
                {
                    b.Navigation("ShopingListIngredients");
                });

            modelBuilder.Entity("Seavus.Recipe.Core.Entities.User", b =>
                {
                    b.Navigation("Recipes");

                    b.Navigation("ShopingList");
                });
#pragma warning restore 612, 618
        }
    }
}