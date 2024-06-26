﻿// <auto-generated />
using System;
using FormulaOne.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FormulaOne.Infrastructure.Migrations
{
    [DbContext(typeof(FormulaOneDbContext))]
    [Migration("20240527154159_initial-migration")]
    partial class initialmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.5");

            modelBuilder.Entity("FormulaOne.Domain.Entities.Achievement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DriverId")
                        .HasColumnType("TEXT");

                    b.Property<int>("FastestLap")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PolePosition")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RaceWins")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("WorldChampionship")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DriverId");

                    b.ToTable("Achievements");
                });

            modelBuilder.Entity("FormulaOne.Domain.Entities.Driver", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<int>("DriverNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("FormulaOne.Domain.Entities.Achievement", b =>
                {
                    b.HasOne("FormulaOne.Domain.Entities.Driver", "Driver")
                        .WithMany("Achievements")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Achievement_Driver");

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("FormulaOne.Domain.Entities.Driver", b =>
                {
                    b.Navigation("Achievements");
                });
#pragma warning restore 612, 618
        }
    }
}
