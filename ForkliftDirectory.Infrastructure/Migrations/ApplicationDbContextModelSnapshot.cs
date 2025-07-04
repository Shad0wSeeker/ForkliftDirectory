﻿// <auto-generated />
using System;
using ForkliftDirectory.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ForkliftDirectory.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ForkliftDirectory.Domain.Entities.Forklift", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<decimal>("LoadCapacity")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasMaxLength(100)
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("isActive")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Forklifts");
                });

            modelBuilder.Entity("ForkliftDirectory.Domain.Entities.ForkliftDowntime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ForkliftId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ForkliftId");

                    b.ToTable("ForkliftDowntimes");
                });

            modelBuilder.Entity("ForkliftDirectory.Domain.Entities.ForkliftDowntime", b =>
                {
                    b.HasOne("ForkliftDirectory.Domain.Entities.Forklift", "Forklift")
                        .WithMany("Downtimes")
                        .HasForeignKey("ForkliftId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Forklift");
                });

            modelBuilder.Entity("ForkliftDirectory.Domain.Entities.Forklift", b =>
                {
                    b.Navigation("Downtimes");
                });
#pragma warning restore 612, 618
        }
    }
}
