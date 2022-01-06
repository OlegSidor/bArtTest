﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using bArtTest.Context;

#nullable disable

namespace bArtTest.Migrations
{
    [DbContext(typeof(MVCContext))]
    partial class MVCContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("bArtTest.Models.Account", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("Incidentname")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id");

                    b.HasIndex("Incidentname");

                    b.HasIndex("name")
                        .IsUnique();

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("bArtTest.Models.Contact", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int?>("Accountid")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firts_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("last_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Accountid");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("bArtTest.Models.Incident", b =>
                {
                    b.Property<string>("name")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("name");

                    b.ToTable("Incidents");
                });

            modelBuilder.Entity("bArtTest.Models.Account", b =>
                {
                    b.HasOne("bArtTest.Models.Incident", null)
                        .WithMany("accounts")
                        .HasForeignKey("Incidentname");
                });

            modelBuilder.Entity("bArtTest.Models.Contact", b =>
                {
                    b.HasOne("bArtTest.Models.Account", null)
                        .WithMany("contacts")
                        .HasForeignKey("Accountid");
                });

            modelBuilder.Entity("bArtTest.Models.Account", b =>
                {
                    b.Navigation("contacts");
                });

            modelBuilder.Entity("bArtTest.Models.Incident", b =>
                {
                    b.Navigation("accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
