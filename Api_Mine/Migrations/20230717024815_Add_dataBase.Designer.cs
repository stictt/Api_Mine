﻿// <auto-generated />
using System;
using Api_Mine.Models.Data_Access;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api_Mine.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20230717024815_Add_dataBase")]
    partial class Add_dataBase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Api_Mine.Models.Data_Access.DrillBlockDatabaseModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("DrillBlockDatabaseModels");
                });

            modelBuilder.Entity("Api_Mine.Models.Data_Access.DrillBlockPointsDatabaseModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DrillBlockId")
                        .HasColumnType("integer");

                    b.Property<double>("X")
                        .HasColumnType("double precision");

                    b.Property<double>("Y")
                        .HasColumnType("double precision");

                    b.Property<double>("Z")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("DrillBlockId");

                    b.ToTable("DrillBlockPointsDatabaseModels");
                });

            modelBuilder.Entity("Api_Mine.Models.Data_Access.HoleDatabaseModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("DEPTH")
                        .HasColumnType("double precision");

                    b.Property<int>("DrillBlockDatabaseModelId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DrillBlockDatabaseModelId");

                    b.ToTable("HoleDatabaseModels");
                });

            modelBuilder.Entity("Api_Mine.Models.Data_Access.HolePointsDatabaseModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("HoleId")
                        .HasColumnType("integer");

                    b.Property<double>("X")
                        .HasColumnType("double precision");

                    b.Property<double>("Y")
                        .HasColumnType("double precision");

                    b.Property<double>("Z")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("HoleId");

                    b.ToTable("HolePointsDatabaseModels");
                });

            modelBuilder.Entity("Api_Mine.Models.Data_Access.PointDatabaseModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DrillBlockPointsDatabaseModelId")
                        .HasColumnType("integer");

                    b.Property<double>("Lat")
                        .HasColumnType("double precision");

                    b.Property<double>("Lng")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("DrillBlockPointsDatabaseModelId");

                    b.ToTable("PointDatabaseModel");
                });

            modelBuilder.Entity("Api_Mine.Models.Data_Access.DrillBlockPointsDatabaseModel", b =>
                {
                    b.HasOne("Api_Mine.Models.Data_Access.DrillBlockDatabaseModel", "DrillBlockDatabaseModel")
                        .WithMany()
                        .HasForeignKey("DrillBlockId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("DrillBlockDatabaseModel");
                });

            modelBuilder.Entity("Api_Mine.Models.Data_Access.HoleDatabaseModel", b =>
                {
                    b.HasOne("Api_Mine.Models.Data_Access.DrillBlockDatabaseModel", "DrillBlockDatabaseModel")
                        .WithMany()
                        .HasForeignKey("DrillBlockDatabaseModelId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("DrillBlockDatabaseModel");
                });

            modelBuilder.Entity("Api_Mine.Models.Data_Access.HolePointsDatabaseModel", b =>
                {
                    b.HasOne("Api_Mine.Models.Data_Access.HoleDatabaseModel", "HoleDatabaseModel")
                        .WithMany()
                        .HasForeignKey("HoleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("HoleDatabaseModel");
                });

            modelBuilder.Entity("Api_Mine.Models.Data_Access.PointDatabaseModel", b =>
                {
                    b.HasOne("Api_Mine.Models.Data_Access.DrillBlockPointsDatabaseModel", "DrillBlockPointsDatabaseModel")
                        .WithMany("Sequence")
                        .HasForeignKey("DrillBlockPointsDatabaseModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DrillBlockPointsDatabaseModel");
                });

            modelBuilder.Entity("Api_Mine.Models.Data_Access.DrillBlockPointsDatabaseModel", b =>
                {
                    b.Navigation("Sequence");
                });
#pragma warning restore 612, 618
        }
    }
}
