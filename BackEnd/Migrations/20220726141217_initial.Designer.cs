﻿// <auto-generated />
using System;
using BackEnd.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackEnd.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220726141217_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BackEnd.Models.FundCollection", b =>
                {
                    b.Property<int>("ReceiptNumber")
                        .HasColumnType("int");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("SessionNumber")
                        .HasColumnType("int");

                    b.HasKey("ReceiptNumber");

                    b.HasIndex("SessionNumber");

                    b.ToTable("FundCollection");
                });

            modelBuilder.Entity("BackEnd.Models.Member", b =>
                {
                    b.Property<int>("CardNumber")
                        .HasColumnType("int");

                    b.Property<string>("Block")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BloodGroup")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoomNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Session")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Year")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CardNumber");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("BackEnd.Models.Purchage", b =>
                {
                    b.Property<int>("SerialNumber")
                        .HasColumnType("int");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("Dated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Items")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SessionNumber")
                        .HasColumnType("int");

                    b.HasKey("SerialNumber");

                    b.HasIndex("SessionNumber");

                    b.ToTable("purchage");
                });

            modelBuilder.Entity("BackEnd.Models.Session", b =>
                {
                    b.Property<int>("SessionNumber")
                        .HasColumnType("int");

                    b.Property<int>("CardNumber")
                        .HasColumnType("int");

                    b.Property<bool>("FirstOfMonth")
                        .HasColumnType("bit");

                    b.Property<string>("ManagerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SessionName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SessionNumber");

                    b.ToTable("Session");
                });

            modelBuilder.Entity("BackEnd.Models.FundCollection", b =>
                {
                    b.HasOne("BackEnd.Models.Session", "Session")
                        .WithMany("FundCollection")
                        .HasForeignKey("SessionNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Session");
                });

            modelBuilder.Entity("BackEnd.Models.Purchage", b =>
                {
                    b.HasOne("BackEnd.Models.Session", "Session")
                        .WithMany("Purchages")
                        .HasForeignKey("SessionNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Session");
                });

            modelBuilder.Entity("BackEnd.Models.Session", b =>
                {
                    b.Navigation("FundCollection");

                    b.Navigation("Purchages");
                });
#pragma warning restore 612, 618
        }
    }
}
