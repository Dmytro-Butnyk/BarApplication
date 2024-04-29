﻿// <auto-generated />
using System;
using DB_Coursework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DB_Coursework.Migrations
{
    [DbContext(typeof(BarContext))]
    [Migration("20240424143608_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.HasSequence("ProductSequence");

            modelBuilder.Entity("DB_Coursework.Models.BaseClasses.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("NEXT VALUE FOR [ProductSequence]");

                    SqlServerPropertyBuilderExtensions.UseSequence(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<double?>("Quantity")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("DB_Coursework.Models.Orders.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Table_IdId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Table_IdId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DB_Coursework.Models.Orders.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Order_IdId")
                        .HasColumnType("int");

                    b.Property<int>("Product_IdId")
                        .HasColumnType("int");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("Order_IdId");

                    b.HasIndex("Product_IdId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("DB_Coursework.Models.Orders.Table", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("DB_Coursework.Models.Products.Supply", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Product_IdId")
                        .HasColumnType("int");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("Product_IdId");

                    b.ToTable("Supplies");
                });

            modelBuilder.Entity("DB_Coursework.Models.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DB_Coursework.Models.Products.AlcoholDrink", b =>
                {
                    b.HasBaseType("DB_Coursework.Models.BaseClasses.Product");

                    b.Property<double>("ABV")
                        .HasColumnType("float");

                    b.ToTable("AlcoholDrinks");
                });

            modelBuilder.Entity("DB_Coursework.Models.Products.Snack", b =>
                {
                    b.HasBaseType("DB_Coursework.Models.BaseClasses.Product");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Snacks");
                });

            modelBuilder.Entity("DB_Coursework.Models.Orders.Order", b =>
                {
                    b.HasOne("DB_Coursework.Models.Orders.Table", "Table_Id")
                        .WithMany()
                        .HasForeignKey("Table_IdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Table_Id");
                });

            modelBuilder.Entity("DB_Coursework.Models.Orders.OrderDetail", b =>
                {
                    b.HasOne("DB_Coursework.Models.Orders.Order", "Order_Id")
                        .WithMany()
                        .HasForeignKey("Order_IdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DB_Coursework.Models.BaseClasses.Product", "Product_Id")
                        .WithMany()
                        .HasForeignKey("Product_IdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order_Id");

                    b.Navigation("Product_Id");
                });

            modelBuilder.Entity("DB_Coursework.Models.Products.Supply", b =>
                {
                    b.HasOne("DB_Coursework.Models.BaseClasses.Product", "Product_Id")
                        .WithMany()
                        .HasForeignKey("Product_IdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product_Id");
                });
#pragma warning restore 612, 618
        }
    }
}
