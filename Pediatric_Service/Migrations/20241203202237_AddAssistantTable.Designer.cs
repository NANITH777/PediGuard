﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pediatric_Service.Models;

#nullable disable

namespace Pediatric_Service.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241203202237_AddAssistantTable")]
    partial class AddAssistantTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Pediatric_Service.Models.Assistant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Assistants");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "123 Main St, Anytown, USA",
                            Email = "john.doe@example.com",
                            FullName = "John Doe",
                            Gender = "Male",
                            Password = "Password123",
                            PhoneNumber = "123-456-7890"
                        },
                        new
                        {
                            Id = 2,
                            Address = "456 Elm St, Othertown, USA",
                            Email = "jane.smith@example.com",
                            FullName = "Jane Smith",
                            Gender = "Female",
                            Password = "Password123",
                            PhoneNumber = "098-765-4321"
                        },
                        new
                        {
                            Id = 3,
                            Address = "789 Oak St, Sometown, USA",
                            Email = "alice.johnson@example.com",
                            FullName = "Morgan Alex",
                            Gender = "Female",
                            Password = "Password123",
                            PhoneNumber = "555-123-4567"
                        });
                });

            modelBuilder.Entity("Pediatric_Service.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CurrentCapacity")
                        .HasColumnType("int");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfBeds")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CurrentCapacity = 15,
                            DoctorId = 1,
                            Name = "Pediatric Emergency",
                            NumberOfBeds = 20
                        },
                        new
                        {
                            Id = 2,
                            CurrentCapacity = 5,
                            DoctorId = 3,
                            Name = "Pediatric Intensive Care",
                            NumberOfBeds = 10
                        },
                        new
                        {
                            Id = 3,
                            CurrentCapacity = 12,
                            DoctorId = 4,
                            Name = "Pediatric Hematology and Oncology",
                            NumberOfBeds = 15
                        });
                });

            modelBuilder.Entity("Pediatric_Service.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "123 Main St, Anytown, USA",
                            Email = "john.smith@example.com",
                            FullName = "Dr. John Smith",
                            Gender = "Male",
                            PhoneNumber = "123-456-7890"
                        },
                        new
                        {
                            Id = 2,
                            Address = "456 Elm St, Othertown, USA",
                            Email = "jane.doe@example.com",
                            FullName = "Dr. Jane Doe",
                            Gender = "Female",
                            PhoneNumber = "098-765-4321"
                        },
                        new
                        {
                            Id = 3,
                            Address = "789 Oak St, Sometown, USA",
                            Email = "emily.johnson@example.com",
                            FullName = "Dr. Emily Johnson",
                            Gender = "Female",
                            PhoneNumber = "555-123-4567"
                        });
                });

            modelBuilder.Entity("Pediatric_Service.Models.Nobet", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<int>("DoctorID")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.HasKey("ID");

                    b.HasIndex("DepartmentID");

                    b.HasIndex("DoctorID");

                    b.ToTable("Nobets");
                });

            modelBuilder.Entity("Pediatric_Service.Models.Department", b =>
                {
                    b.HasOne("Pediatric_Service.Models.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("Pediatric_Service.Models.Nobet", b =>
                {
                    b.HasOne("Pediatric_Service.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pediatric_Service.Models.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Doctor");
                });
#pragma warning restore 612, 618
        }
    }
}
