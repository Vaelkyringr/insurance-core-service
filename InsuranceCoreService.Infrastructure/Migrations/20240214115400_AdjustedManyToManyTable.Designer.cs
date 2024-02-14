﻿// <auto-generated />
using System;
using InsuranceCoreService.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InsuranceCoreService.Infrastructure.Migrations
{
    [DbContext(typeof(InsuranceDbContext))]
    [Migration("20240214115400_AdjustedManyToManyTable")]
    partial class AdjustedManyToManyTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CoverageInsurance", b =>
                {
                    b.Property<int>("CoveragesId")
                        .HasColumnType("int");

                    b.Property<int>("InsurancesId")
                        .HasColumnType("int");

                    b.HasKey("CoveragesId", "InsurancesId");

                    b.HasIndex("InsurancesId");

                    b.ToTable("InsuranceCoverage", (string)null);
                });

            modelBuilder.Entity("InsuranceCoreService.Domain.CoverageAggregate.Coverage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("BaseAmount")
                        .HasColumnType("decimal(18,4)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Coverages", (string)null);
                });

            modelBuilder.Entity("InsuranceCoreService.Domain.CoverageAggregate.InsuranceCoverage", b =>
                {
                    b.Property<int>("InsuranceId")
                        .HasColumnType("int");

                    b.Property<int>("CoverageId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("InsuranceId", "CoverageId");

                    b.HasIndex("CoverageId");

                    b.ToTable("InsuranceCoverages", (string)null);
                });

            modelBuilder.Entity("InsuranceCoreService.Domain.InsuranceAggregate.Insurance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndPeriod")
                        .HasColumnType("datetime2");

                    b.Property<string>("InsuranceNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InsurerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartPeriod")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("YearlyPremium")
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("Id");

                    b.HasIndex("InsurerId");

                    b.ToTable("Insurances", (string)null);
                });

            modelBuilder.Entity("InsuranceCoreService.Domain.InsurerAggregate.Insurer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Insurers", (string)null);
                });

            modelBuilder.Entity("CoverageInsurance", b =>
                {
                    b.HasOne("InsuranceCoreService.Domain.CoverageAggregate.Coverage", null)
                        .WithMany()
                        .HasForeignKey("CoveragesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InsuranceCoreService.Domain.InsuranceAggregate.Insurance", null)
                        .WithMany()
                        .HasForeignKey("InsurancesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InsuranceCoreService.Domain.CoverageAggregate.InsuranceCoverage", b =>
                {
                    b.HasOne("InsuranceCoreService.Domain.CoverageAggregate.Coverage", "Coverage")
                        .WithMany()
                        .HasForeignKey("CoverageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InsuranceCoreService.Domain.InsuranceAggregate.Insurance", "Insurance")
                        .WithMany()
                        .HasForeignKey("InsuranceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coverage");

                    b.Navigation("Insurance");
                });

            modelBuilder.Entity("InsuranceCoreService.Domain.InsuranceAggregate.Insurance", b =>
                {
                    b.HasOne("InsuranceCoreService.Domain.InsurerAggregate.Insurer", "Insurer")
                        .WithMany("Insurances")
                        .HasForeignKey("InsurerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Insurer");
                });

            modelBuilder.Entity("InsuranceCoreService.Domain.InsurerAggregate.Insurer", b =>
                {
                    b.Navigation("Insurances");
                });
#pragma warning restore 612, 618
        }
    }
}
