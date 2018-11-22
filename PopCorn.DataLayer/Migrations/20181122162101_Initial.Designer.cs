﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PopCorn.DataLayer.Context;

namespace PopCorn.DataLayer.Migrations
{
    [DbContext(typeof(PopCornDbContext))]
    [Migration("20181122162101_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PopCorn.DataLayer.Models.FinanceCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int?>("ParentCategoryId");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("FinanceCategories");
                });

            modelBuilder.Entity("PopCorn.DataLayer.Models.FinanceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("FinanceTypes");
                });

            modelBuilder.Entity("PopCorn.DataLayer.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CanceledDate");

                    b.Property<DateTime?>("ClosedDate");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Description");

                    b.Property<double>("EstimatedPrice");

                    b.Property<string>("Name");

                    b.Property<int>("ParentCategoryId");

                    b.Property<DateTime?>("StartedDate");

                    b.Property<int>("StatusId");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("PopCorn.DataLayer.Models.ProjectFinance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount");

                    b.Property<int?>("FinanceCategoryId");

                    b.Property<int?>("FinanceTypeId");

                    b.Property<string>("Note");

                    b.Property<DateTime>("OperationDate");

                    b.Property<int>("ProjectId");

                    b.HasKey("Id");

                    b.HasIndex("FinanceCategoryId");

                    b.HasIndex("FinanceTypeId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectFinance");
                });

            modelBuilder.Entity("PopCorn.DataLayer.Models.ProjectStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ProjectStatuses");
                });

            modelBuilder.Entity("PopCorn.DataLayer.Models.FinanceCategory", b =>
                {
                    b.HasOne("PopCorn.DataLayer.Models.FinanceCategory", "ParentCategory")
                        .WithMany("SubCategories")
                        .HasForeignKey("ParentCategoryId");
                });

            modelBuilder.Entity("PopCorn.DataLayer.Models.Project", b =>
                {
                    b.HasOne("PopCorn.DataLayer.Models.ProjectStatus", "Status")
                        .WithMany("Projects")
                        .HasForeignKey("ParentCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PopCorn.DataLayer.Models.ProjectFinance", b =>
                {
                    b.HasOne("PopCorn.DataLayer.Models.FinanceCategory", "FinanceCategory")
                        .WithMany("Finances")
                        .HasForeignKey("FinanceCategoryId");

                    b.HasOne("PopCorn.DataLayer.Models.FinanceType", "FinanceType")
                        .WithMany("Finances")
                        .HasForeignKey("FinanceTypeId");

                    b.HasOne("PopCorn.DataLayer.Models.Project", "Project")
                        .WithMany("Finance")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
