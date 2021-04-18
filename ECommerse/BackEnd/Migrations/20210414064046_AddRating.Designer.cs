﻿// <auto-generated />
using System;
using BackEnd.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BackEnd.Migrations
{
    [DbContext(typeof(AplicationDbContext))]
    [Migration("20210414064046_AddRating")]
    partial class AddRating
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BackEnd.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Hair"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Makeup"
                        },
                        new
                        {
                            ID = 3,
                            Name = "SkinCare"
                        },
                        new
                        {
                            ID = 4,
                            Name = "Fragnance"
                        });
                });

            modelBuilder.Entity("BackEnd.Models.Product", b =>
                {
                    b.Property<int>("proID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("proDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("proName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("proPrice")
                        .HasColumnType("float");

                    b.HasKey("proID");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            proID = 1,
                            CategoryId = 1,
                            Image = "p1.webp",
                            proDescription = "Product Desscription",
                            proName = "Product Name 1",
                            proPrice = 50.0
                        },
                        new
                        {
                            proID = 2,
                            CategoryId = 1,
                            Image = "p3.webp",
                            proDescription = "Product Desscription",
                            proName = "Product Name 2",
                            proPrice = 50.0
                        },
                        new
                        {
                            proID = 3,
                            CategoryId = 1,
                            Image = "p4.webp",
                            proDescription = "Product Desscription",
                            proName = "Product Name 3",
                            proPrice = 50.0
                        },
                        new
                        {
                            proID = 4,
                            CategoryId = 1,
                            Image = "p5.webp",
                            proDescription = "Product Desscription",
                            proName = "Product Name 4",
                            proPrice = 50.0
                        },
                        new
                        {
                            proID = 5,
                            CategoryId = 2,
                            Image = "p1.webp",
                            proDescription = "Product Desscription",
                            proName = "Product Name 6",
                            proPrice = 50.0
                        },
                        new
                        {
                            proID = 6,
                            CategoryId = 2,
                            Image = "p3.webp",
                            proDescription = "Product Desscription",
                            proName = "Product Name 7",
                            proPrice = 50.0
                        },
                        new
                        {
                            proID = 7,
                            CategoryId = 2,
                            Image = "p4.webp",
                            proDescription = "Product Desscription",
                            proName = "Product Name 8",
                            proPrice = 50.0
                        },
                        new
                        {
                            proID = 8,
                            CategoryId = 2,
                            Image = "p5.webp",
                            proDescription = "Product Desscription",
                            proName = "Product Name 9",
                            proPrice = 50.0
                        },
                        new
                        {
                            proID = 9,
                            CategoryId = 3,
                            Image = "p1.webp",
                            proDescription = "Product Desscription",
                            proName = "Product Name 10",
                            proPrice = 50.0
                        },
                        new
                        {
                            proID = 10,
                            CategoryId = 3,
                            Image = "p3.webp",
                            proDescription = "Product Desscription",
                            proName = "Product Name 11",
                            proPrice = 50.0
                        },
                        new
                        {
                            proID = 11,
                            CategoryId = 3,
                            Image = "p4.webp",
                            proDescription = "Product Desscription",
                            proName = "Product Name 12",
                            proPrice = 50.0
                        },
                        new
                        {
                            proID = 12,
                            CategoryId = 3,
                            Image = "p5.webp",
                            proDescription = "Product Desscription",
                            proName = "Product Name 13",
                            proPrice = 50.0
                        },
                        new
                        {
                            proID = 13,
                            CategoryId = 4,
                            Image = "p1.webp",
                            proDescription = "Product Desscription",
                            proName = "Product Name 14",
                            proPrice = 50.0
                        },
                        new
                        {
                            proID = 14,
                            CategoryId = 4,
                            Image = "p3.webp",
                            proDescription = "Product Desscription",
                            proName = "Product Name 15",
                            proPrice = 50.0
                        },
                        new
                        {
                            proID = 15,
                            CategoryId = 4,
                            Image = "p4.webp",
                            proDescription = "Product Desscription",
                            proName = "Product Name 16",
                            proPrice = 50.0
                        },
                        new
                        {
                            proID = 16,
                            CategoryId = 4,
                            Image = "p5.webp",
                            proDescription = "Product Desscription",
                            proName = "Product Name 17",
                            proPrice = 50.0
                        });
                });

            modelBuilder.Entity("BackEnd.Models.Rating", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Feedback")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.Property<string>("UserAcc")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("ProductID");

                    b.HasIndex("UserAcc");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("BackEnd.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BackEnd.Models.Product", b =>
                {
                    b.HasOne("BackEnd.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("BackEnd.Models.Rating", b =>
                {
                    b.HasOne("BackEnd.Models.Product", "Product")
                        .WithMany("Ratings")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEnd.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserAcc");

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BackEnd.Models.Product", b =>
                {
                    b.Navigation("Ratings");
                });
#pragma warning restore 612, 618
        }
    }
}