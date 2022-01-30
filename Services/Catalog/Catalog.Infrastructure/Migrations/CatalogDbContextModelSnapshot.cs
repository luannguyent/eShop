﻿// <auto-generated />
using Catalog.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Catalog.Infrastructure.Migrations
{
    [DbContext(typeof(CatalogDbContext))]
    partial class CatalogDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.HasSequence("catalog_hilo")
                .IncrementsBy(10);

            modelBuilder.HasSequence("catalog_type_hilo")
                .IncrementsBy(10);

            modelBuilder.Entity("Catalog.Domain.CatalogAggregate.CatalogBrand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CatalogBrand", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Azure"
                        },
                        new
                        {
                            Id = 2,
                            Brand = ".NET"
                        },
                        new
                        {
                            Id = 3,
                            Brand = "Visual Studio"
                        },
                        new
                        {
                            Id = 4,
                            Brand = "SQL Server"
                        },
                        new
                        {
                            Id = 5,
                            Brand = "Other"
                        });
                });

            modelBuilder.Entity("Catalog.Domain.CatalogAggregate.CatalogItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "catalog_hilo");

                    b.Property<int>("AvailableStock")
                        .HasColumnType("int");

                    b.Property<int>("CatalogBrandId")
                        .HasColumnType("int");

                    b.Property<int>("CatalogTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxStockThreshold")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("OnReorder")
                        .HasColumnType("bit");

                    b.Property<string>("PictureFileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("RestockThreshold")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CatalogBrandId");

                    b.HasIndex("CatalogTypeId");

                    b.ToTable("Catalog", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AvailableStock = 100,
                            CatalogBrandId = 2,
                            CatalogTypeId = 2,
                            Description = ".NET Bot Black Hoodie",
                            MaxStockThreshold = 0,
                            Name = ".NET Bot Black Hoodie",
                            OnReorder = false,
                            PictureFileName = "1.png",
                            Price = 19.5m,
                            RestockThreshold = 0
                        },
                        new
                        {
                            Id = 2,
                            AvailableStock = 100,
                            CatalogBrandId = 2,
                            CatalogTypeId = 1,
                            Description = ".NET Black & White Mug",
                            MaxStockThreshold = 0,
                            Name = ".NET Black & White Mug",
                            OnReorder = false,
                            PictureFileName = "2.png",
                            Price = 8.50m,
                            RestockThreshold = 0
                        },
                        new
                        {
                            Id = 3,
                            AvailableStock = 100,
                            CatalogBrandId = 5,
                            CatalogTypeId = 2,
                            Description = "Prism White T-Shirt",
                            MaxStockThreshold = 0,
                            Name = "Prism White T-Shirt",
                            OnReorder = false,
                            PictureFileName = "3.png",
                            Price = 12m,
                            RestockThreshold = 0
                        },
                        new
                        {
                            Id = 4,
                            AvailableStock = 100,
                            CatalogBrandId = 2,
                            CatalogTypeId = 2,
                            Description = ".NET Foundation T-shirt",
                            MaxStockThreshold = 0,
                            Name = ".NET Foundation T-shirt",
                            OnReorder = false,
                            PictureFileName = "4.png",
                            Price = 12m,
                            RestockThreshold = 0
                        },
                        new
                        {
                            Id = 5,
                            AvailableStock = 100,
                            CatalogBrandId = 5,
                            CatalogTypeId = 3,
                            Description = "Roslyn Red Sheet",
                            MaxStockThreshold = 0,
                            Name = "Roslyn Red Sheet",
                            OnReorder = false,
                            PictureFileName = "5.png",
                            Price = 8.5m,
                            RestockThreshold = 0
                        },
                        new
                        {
                            Id = 6,
                            AvailableStock = 100,
                            CatalogBrandId = 2,
                            CatalogTypeId = 2,
                            Description = ".NET Blue Hoodie",
                            MaxStockThreshold = 0,
                            Name = ".NET Blue Hoodie",
                            OnReorder = false,
                            PictureFileName = "6.png",
                            Price = 12m,
                            RestockThreshold = 0
                        },
                        new
                        {
                            Id = 7,
                            AvailableStock = 100,
                            CatalogBrandId = 5,
                            CatalogTypeId = 2,
                            Description = "Roslyn Red T-Shirt",
                            MaxStockThreshold = 0,
                            Name = "Roslyn Red T-Shirt",
                            OnReorder = false,
                            PictureFileName = "7.png",
                            Price = 12m,
                            RestockThreshold = 0
                        },
                        new
                        {
                            Id = 8,
                            AvailableStock = 100,
                            CatalogBrandId = 5,
                            CatalogTypeId = 2,
                            Description = "Kudu Purple Hoodie",
                            MaxStockThreshold = 0,
                            Name = "Kudu Purple Hoodie",
                            OnReorder = false,
                            PictureFileName = "8.png",
                            Price = 8.5m,
                            RestockThreshold = 0
                        },
                        new
                        {
                            Id = 9,
                            AvailableStock = 100,
                            CatalogBrandId = 5,
                            CatalogTypeId = 1,
                            Description = "Cup<T> White Mug",
                            MaxStockThreshold = 0,
                            Name = "Cup<T> White Mug",
                            OnReorder = false,
                            PictureFileName = "9.png",
                            Price = 12m,
                            RestockThreshold = 0
                        },
                        new
                        {
                            Id = 10,
                            AvailableStock = 100,
                            CatalogBrandId = 2,
                            CatalogTypeId = 3,
                            Description = ".NET Foundation Sheet",
                            MaxStockThreshold = 0,
                            Name = ".NET Foundation Sheet",
                            OnReorder = false,
                            PictureFileName = "10.png",
                            Price = 12m,
                            RestockThreshold = 0
                        },
                        new
                        {
                            Id = 11,
                            AvailableStock = 100,
                            CatalogBrandId = 2,
                            CatalogTypeId = 3,
                            Description = "Cup<T> Sheet",
                            MaxStockThreshold = 0,
                            Name = "Cup<T> Sheet",
                            OnReorder = false,
                            PictureFileName = "11.png",
                            Price = 8.5m,
                            RestockThreshold = 0
                        },
                        new
                        {
                            Id = 12,
                            AvailableStock = 100,
                            CatalogBrandId = 5,
                            CatalogTypeId = 2,
                            Description = "Prism White TShirt",
                            MaxStockThreshold = 0,
                            Name = "Prism White TShirt",
                            OnReorder = false,
                            PictureFileName = "12.png",
                            Price = 12m,
                            RestockThreshold = 0
                        });
                });

            modelBuilder.Entity("Catalog.Domain.CatalogAggregate.CatalogType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "catalog_type_hilo");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("CatalogType", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Mug"
                        },
                        new
                        {
                            Id = 2,
                            Type = "T-Shirt"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Sheet"
                        },
                        new
                        {
                            Id = 4,
                            Type = "USB Memory Stick"
                        });
                });

            modelBuilder.Entity("Catalog.Domain.CatalogAggregate.CatalogItem", b =>
                {
                    b.HasOne("Catalog.Domain.CatalogAggregate.CatalogBrand", "CatalogBrand")
                        .WithMany()
                        .HasForeignKey("CatalogBrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Catalog.Domain.CatalogAggregate.CatalogType", "CatalogType")
                        .WithMany()
                        .HasForeignKey("CatalogTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CatalogBrand");

                    b.Navigation("CatalogType");
                });
#pragma warning restore 612, 618
        }
    }
}