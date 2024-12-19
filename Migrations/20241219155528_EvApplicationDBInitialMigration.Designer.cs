﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Software_Foundations_Learning_Programme_.DbContexts;

#nullable disable

namespace Software_Foundations_Learning_Programme_.Migrations
{
    [DbContext(typeof(EvGrantApplicationContext))]
    [Migration("20241219155528_EvApplicationDBInitialMigration")]
    partial class EvApplicationDBInitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("Software_Foundations_Learning_Programme_.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address_line1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Address_line2")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("Postcode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Software_Foundations_Learning_Programme_.Entities.Application", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AddressId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Vrn")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("Software_Foundations_Learning_Programme_.Entities.Vehicle", b =>
                {
                    b.Property<string>("Vrn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Fuel_type")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("Make")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("Model")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<int?>("Year_made")
                        .HasColumnType("INTEGER");

                    b.HasKey("Vrn");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("Software_Foundations_Learning_Programme_.Entities.Application", b =>
                {
                    b.HasOne("Software_Foundations_Learning_Programme_.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });
#pragma warning restore 612, 618
        }
    }
}
