﻿// <auto-generated />
using System;
using InsuranceSystem.API.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InsuranceSystem.API.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20231114202741_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InsuranceSystem.Domain.Policy.PolicyHolder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NationalIDNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PolicyNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("PolicyHolders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateCreated = new DateTime(2023, 11, 15, 0, 27, 41, 284, DateTimeKind.Local).AddTicks(8300),
                            DateModified = new DateTime(2023, 11, 15, 0, 27, 41, 284, DateTimeKind.Local).AddTicks(8340),
                            DateOfBirth = new DateTime(2000, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Precious",
                            NationalIDNumber = "NGN0014AA",
                            PolicyNumber = "H2441",
                            Surname = "Chukwuma"
                        },
                        new
                        {
                            Id = 2,
                            DateCreated = new DateTime(2023, 11, 15, 0, 27, 41, 284, DateTimeKind.Local).AddTicks(8350),
                            DateModified = new DateTime(2023, 11, 15, 0, 27, 41, 284, DateTimeKind.Local).AddTicks(8350),
                            DateOfBirth = new DateTime(2001, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Gladys",
                            NationalIDNumber = "NGN0024AA",
                            PolicyNumber = "H2442",
                            Surname = "Chukwuma"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
