﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineShoppingWebAPI.Data;

#nullable disable

namespace OnlineShoppingWebAPI.Migrations
{
    [DbContext(typeof(ShoppingDbContext))]
    partial class ShoppingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("OnlineShoppingWebAPI.Models.Order", b =>
                {
                    b.Property<int>("Orderid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Orderid"), 1L, 1);

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderQuantity")
                        .HasColumnType("int");

                    b.Property<float>("OrderTotalAmount")
                        .HasColumnType("real");

                    b.Property<int?>("Userid")
                        .HasColumnType("int");

                    b.HasKey("Orderid");

                    b.HasIndex("Userid");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OnlineShoppingWebAPI.Models.Payment", b =>
                {
                    b.Property<int>("Paymentid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Paymentid"), 1L, 1);

                    b.Property<int?>("Orderid")
                        .HasColumnType("int");

                    b.Property<string>("PaymentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Userid")
                        .HasColumnType("int");

                    b.HasKey("Paymentid");

                    b.HasIndex("Orderid");

                    b.HasIndex("Userid");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("OnlineShoppingWebAPI.Models.TransactionHistory", b =>
                {
                    b.Property<int>("TransactionReportid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionReportid"), 1L, 1);

                    b.Property<int?>("Orderid")
                        .HasColumnType("int");

                    b.Property<int?>("Paymentid")
                        .HasColumnType("int");

                    b.Property<int?>("Userid")
                        .HasColumnType("int");

                    b.HasKey("TransactionReportid");

                    b.HasIndex("Orderid");

                    b.HasIndex("Paymentid");

                    b.HasIndex("Userid");

                    b.ToTable("TransactionHistorys");
                });

            modelBuilder.Entity("OnlineShoppingWebAPI.Models.User", b =>
                {
                    b.Property<int>("Userid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Userid"), 1L, 1);

                    b.Property<string>("UserAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserContact")
                        .HasColumnType("int");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserFirstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserLastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Usertypeid")
                        .HasColumnType("int");

                    b.HasKey("Userid");

                    b.HasIndex("Usertypeid");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("OnlineShoppingWebAPI.Models.UserType", b =>
                {
                    b.Property<int>("Usertypeid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Usertypeid"), 1L, 1);

                    b.Property<string>("Usertype")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Usertypeid");

                    b.ToTable("UserTypes");
                });

            modelBuilder.Entity("OnlineShoppingWebAPI.Models.Order", b =>
                {
                    b.HasOne("OnlineShoppingWebAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("Userid");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OnlineShoppingWebAPI.Models.Payment", b =>
                {
                    b.HasOne("OnlineShoppingWebAPI.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("Orderid");

                    b.HasOne("OnlineShoppingWebAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("Userid");

                    b.Navigation("Order");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OnlineShoppingWebAPI.Models.TransactionHistory", b =>
                {
                    b.HasOne("OnlineShoppingWebAPI.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("Orderid");

                    b.HasOne("OnlineShoppingWebAPI.Models.Payment", "Payment")
                        .WithMany()
                        .HasForeignKey("Paymentid");

                    b.HasOne("OnlineShoppingWebAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("Userid");

                    b.Navigation("Order");

                    b.Navigation("Payment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OnlineShoppingWebAPI.Models.User", b =>
                {
                    b.HasOne("OnlineShoppingWebAPI.Models.UserType", "UserType")
                        .WithMany()
                        .HasForeignKey("Usertypeid");

                    b.Navigation("UserType");
                });
#pragma warning restore 612, 618
        }
    }
}