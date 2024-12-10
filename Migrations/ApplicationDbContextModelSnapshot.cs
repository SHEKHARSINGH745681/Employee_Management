﻿// <auto-generated />
using System;
using EmployeeAdminPortal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EmployeeAdminPortal.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EmployeeAdminPortal.Moddels.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Lastname")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Salary")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("EmployeeAdminPortal.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("EmployeeAdminPortal.Models.Entity.Address", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .HasColumnType("text");

                    b.Property<string>("ZipCode")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("EmployeeAdminPortal.Models.Entity.Cattle", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("Breed")
                        .HasColumnType("text");

                    b.Property<string>("HealthStatus")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Cattle");
                });

            modelBuilder.Entity("EmployeeAdminPortal.Models.Entity.Crop", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("CropName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HarvestDate")
                        .HasColumnType("text");

                    b.Property<double>("Quantity")
                        .HasColumnType("double precision");

                    b.Property<string>("Season")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Crops");
                });

            modelBuilder.Entity("EmployeeAdminPortal.Models.Entity.Farmer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AadharNumber")
                        .HasColumnType("text");

                    b.Property<int>("AddressId")
                        .HasColumnType("integer");

                    b.Property<string>("BankAccountNumber")
                        .HasColumnType("text");

                    b.Property<int>("CattleId")
                        .HasColumnType("integer");

                    b.Property<int>("CropId")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<int?>("ImageId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PanNumber")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Farmers");
                });

            modelBuilder.Entity("EmployeeAdminPortal.Models.Entity.UploadImage", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<byte[]>("ImageData")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("UploadImages");
                });

            modelBuilder.Entity("EmployeeAdminPortal.Moddels.Entities.Employee", b =>
                {
                    b.HasOne("EmployeeAdminPortal.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("EmployeeAdminPortal.Models.Entity.Address", b =>
                {
                    b.HasOne("EmployeeAdminPortal.Models.Entity.Farmer", null)
                        .WithOne("Address")
                        .HasForeignKey("EmployeeAdminPortal.Models.Entity.Address", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EmployeeAdminPortal.Models.Entity.Cattle", b =>
                {
                    b.HasOne("EmployeeAdminPortal.Models.Entity.Farmer", null)
                        .WithOne("Cattle")
                        .HasForeignKey("EmployeeAdminPortal.Models.Entity.Cattle", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EmployeeAdminPortal.Models.Entity.Crop", b =>
                {
                    b.HasOne("EmployeeAdminPortal.Models.Entity.Farmer", null)
                        .WithOne("Crop")
                        .HasForeignKey("EmployeeAdminPortal.Models.Entity.Crop", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EmployeeAdminPortal.Models.Entity.UploadImage", b =>
                {
                    b.HasOne("EmployeeAdminPortal.Models.Entity.Farmer", null)
                        .WithOne("UploadImage")
                        .HasForeignKey("EmployeeAdminPortal.Models.Entity.UploadImage", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EmployeeAdminPortal.Models.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("EmployeeAdminPortal.Models.Entity.Farmer", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("Cattle");

                    b.Navigation("Crop");

                    b.Navigation("UploadImage");
                });
#pragma warning restore 612, 618
        }
    }
}
