﻿// <auto-generated />
using System;
using Market.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GB_Market.Migrations
{
    [DbContext(typeof(ProductContext))]
    partial class ProductContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GB_Market.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("character varying(1024)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("name");

                    b.Property<int?>("ProductGroupId")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("product_pkey");

                    b.HasIndex("ProductGroupId");

                    b.ToTable("products", (string)null);
                });

            modelBuilder.Entity("GB_Market.Models.ProductGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("productgroup_pkey");

                    b.ToTable("productgroups", (string)null);
                });

            modelBuilder.Entity("GB_Market.Models.ProductStorage", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("StorageId")
                        .HasColumnType("integer");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.HasKey("ProductId", "StorageId")
                        .HasName("product_storage_pkey");

                    b.HasIndex("StorageId");

                    b.ToTable("ProductStorage");
                });

            modelBuilder.Entity("GB_Market.Models.Storage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("storage_pkey");

                    b.ToTable("storage", (string)null);
                });

            modelBuilder.Entity("GB_Market.Models.Product", b =>
                {
                    b.HasOne("GB_Market.Models.ProductGroup", "ProductGroup")
                        .WithMany("Products")
                        .HasForeignKey("ProductGroupId");

                    b.Navigation("ProductGroup");
                });

            modelBuilder.Entity("GB_Market.Models.ProductStorage", b =>
                {
                    b.HasOne("GB_Market.Models.Product", "Product")
                        .WithMany("Storages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GB_Market.Models.Storage", "Storage")
                        .WithMany("Products")
                        .HasForeignKey("StorageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Storage");
                });

            modelBuilder.Entity("GB_Market.Models.Product", b =>
                {
                    b.Navigation("Storages");
                });

            modelBuilder.Entity("GB_Market.Models.ProductGroup", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("GB_Market.Models.Storage", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}