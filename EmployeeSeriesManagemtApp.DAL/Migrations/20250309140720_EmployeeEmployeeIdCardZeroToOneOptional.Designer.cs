﻿// <auto-generated />
using System;
using EmployeeSeriesManagemtApp.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeeSeriesManagemtApp.DAL.Migrations
{
    [DbContext(typeof(EmployeeSeriesDbContext))]
    [Migration("20250309140720_EmployeeEmployeeIdCardZeroToOneOptional")]
    partial class EmployeeEmployeeIdCardZeroToOneOptional
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AddressEmployee", b =>
                {
                    b.Property<int>("AddressesId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeesExternalIdf")
                        .HasColumnType("int");

                    b.HasKey("AddressesId", "EmployeesExternalIdf");

                    b.HasIndex("EmployeesExternalIdf");

                    b.ToTable("AddressEmployee");
                });

            modelBuilder.Entity("EmployeeSeries", b =>
                {
                    b.Property<int>("EmployeesExternalIdf")
                        .HasColumnType("int");

                    b.Property<int>("SeriesCode")
                        .HasColumnType("int");

                    b.HasKey("EmployeesExternalIdf", "SeriesCode");

                    b.HasIndex("SeriesCode");

                    b.ToTable("EmployeeSeries");
                });

            modelBuilder.Entity("EmployeeSeriesManagemt.Entities.Entity.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AddressTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Building")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Floor")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("MailBoxNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("Id");

                    b.HasIndex("AddressTypeId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("EmployeeSeriesManagemt.Entities.Entity.AddressType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("AddressTypes");
                });

            modelBuilder.Entity("EmployeeSeriesManagemt.Entities.Entity.Employee", b =>
                {
                    b.Property<int>("ExternalIdf")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExternalIdf"));

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("BirthPlace")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly?>("ExitDate")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nationality")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("OrganizationalUnit")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<byte[]>("ProfileImage")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("SecondName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("ExternalIdf");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EmployeeSeriesManagemt.Entities.Entity.EmployeeIdCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("EmployeesExternalIdf")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Validity")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("EmployeesExternalIdf");

                    b.ToTable("EmployeeIdCards");
                });

            modelBuilder.Entity("EmployeeSeriesManagemt.Entities.Entity.Series", b =>
                {
                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Code"));

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date");

                    b.HasKey("Code");

                    b.ToTable("Series");
                });

            modelBuilder.Entity("AddressEmployee", b =>
                {
                    b.HasOne("EmployeeSeriesManagemt.Entities.Entity.Address", null)
                        .WithMany()
                        .HasForeignKey("AddressesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeeSeriesManagemt.Entities.Entity.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesExternalIdf")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EmployeeSeries", b =>
                {
                    b.HasOne("EmployeeSeriesManagemt.Entities.Entity.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesExternalIdf")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeeSeriesManagemt.Entities.Entity.Series", null)
                        .WithMany()
                        .HasForeignKey("SeriesCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EmployeeSeriesManagemt.Entities.Entity.Address", b =>
                {
                    b.HasOne("EmployeeSeriesManagemt.Entities.Entity.AddressType", "AddressType")
                        .WithMany("Address")
                        .HasForeignKey("AddressTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AddressType");
                });

            modelBuilder.Entity("EmployeeSeriesManagemt.Entities.Entity.EmployeeIdCard", b =>
                {
                    b.HasOne("EmployeeSeriesManagemt.Entities.Entity.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeesExternalIdf");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("EmployeeSeriesManagemt.Entities.Entity.AddressType", b =>
                {
                    b.Navigation("Address");
                });
#pragma warning restore 612, 618
        }
    }
}
