﻿// <auto-generated />
using System;
using LutryShop.OrderApi.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LutryShop.OrderApi.Migrations
{
    [DbContext(typeof(MySqlContext))]
    partial class MySqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LutryShop.OrderApi.Models.OrderDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<long>("OrderHeaderId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<string>("ProductName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("OrderHeaderId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("LutryShop.OrderApi.Models.OrderHeader", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("CVV")
                        .HasColumnType("longtext");

                    b.Property<string>("CardNumber")
                        .HasColumnType("longtext");

                    b.Property<int>("CartTotalItems")
                        .HasColumnType("int");

                    b.Property<string>("CouponCode")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime");

                    b.Property<decimal>("DiscountAmount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("ExpiryMonthYear")
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("OrderTime")
                        .HasColumnType("datetime");

                    b.Property<bool>("PaymentStatus")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext");

                    b.Property<decimal>("PurchaseAmount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("UserId")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("OrderHeaders");
                });

            modelBuilder.Entity("LutryShop.OrderApi.Models.OrderDetail", b =>
                {
                    b.HasOne("LutryShop.OrderApi.Models.OrderHeader", "OrderHeader")
                        .WithMany("CartDetails")
                        .HasForeignKey("OrderHeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderHeader");
                });

            modelBuilder.Entity("LutryShop.OrderApi.Models.OrderHeader", b =>
                {
                    b.Navigation("CartDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
