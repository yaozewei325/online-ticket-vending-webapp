﻿// <auto-generated />
using System;
using BilletDeConcert.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BilletDeConcert.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("BilletDeConcert.Models.Artiste", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhotoURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Artistes");
                });

            modelBuilder.Entity("BilletDeConcert.Models.Artiste_Concert", b =>
                {
                    b.Property<int>("ArtisteId")
                        .HasColumnType("int");

                    b.Property<int>("ConcertId")
                        .HasColumnType("int");

                    b.HasKey("ArtisteId", "ConcertId");

                    b.HasIndex("ConcertId");

                    b.ToTable("Artiste_Concerts");
                });

            modelBuilder.Entity("BilletDeConcert.Models.Concert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CinemaId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Genre")
                        .HasColumnType("int");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Prix")
                        .HasColumnType("float");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Concerts");
                });

            modelBuilder.Entity("BilletDeConcert.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BilletDeConcert.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("ConcertId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<double>("Prix")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ConcertId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("BilletDeConcert.Models.ShoppingCartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int?>("ConcertId")
                        .HasColumnType("int");

                    b.Property<string>("ShoppingCartId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ConcertId");

                    b.ToTable("ShoppingCartItems");
                });

            modelBuilder.Entity("BilletDeConcert.Models.Artiste_Concert", b =>
                {
                    b.HasOne("BilletDeConcert.Models.Artiste", "Artiste")
                        .WithMany("Artiste_Concerts")
                        .HasForeignKey("ArtisteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BilletDeConcert.Models.Concert", "Concert")
                        .WithMany("Artiste_Concerts")
                        .HasForeignKey("ConcertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artiste");

                    b.Navigation("Concert");
                });

            modelBuilder.Entity("BilletDeConcert.Models.OrderItem", b =>
                {
                    b.HasOne("BilletDeConcert.Models.Concert", "Concert")
                        .WithMany()
                        .HasForeignKey("ConcertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BilletDeConcert.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Concert");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("BilletDeConcert.Models.ShoppingCartItem", b =>
                {
                    b.HasOne("BilletDeConcert.Models.Concert", "Concert")
                        .WithMany()
                        .HasForeignKey("ConcertId");

                    b.Navigation("Concert");
                });

            modelBuilder.Entity("BilletDeConcert.Models.Artiste", b =>
                {
                    b.Navigation("Artiste_Concerts");
                });

            modelBuilder.Entity("BilletDeConcert.Models.Concert", b =>
                {
                    b.Navigation("Artiste_Concerts");
                });

            modelBuilder.Entity("BilletDeConcert.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
