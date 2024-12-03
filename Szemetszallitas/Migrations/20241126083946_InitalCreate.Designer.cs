﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Szemetszallitas.Data;

#nullable disable

namespace Szemetszallitas.Migrations
{
    [DbContext(typeof(SzemetszallitasContext))]
    [Migration("20241126083946_InitalCreate")]
    partial class InitalCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Szemetszallitas.Models.Lakig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("SzolgaltatasId")
                        .HasColumnType("int");

                    b.Property<int>("Szolgid")
                        .HasColumnType("int");

                    b.Property<DateTime>("igeny")
                        .HasColumnType("datetime2");

                    b.Property<int>("mennyiseg")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SzolgaltatasId");

                    b.ToTable("Lakig");
                });

            modelBuilder.Entity("Szemetszallitas.Models.Naptar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("SzolgId")
                        .HasColumnType("int");

                    b.Property<int?>("SzolgaltatasId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("datum")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("SzolgaltatasId");

                    b.ToTable("Naptar");
                });

            modelBuilder.Entity("Szemetszallitas.Models.Szolgaltatas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("jelentes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tipus")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Szolgaltatas");
                });

            modelBuilder.Entity("Szemetszallitas.Models.Lakig", b =>
                {
                    b.HasOne("Szemetszallitas.Models.Szolgaltatas", "Szolgaltatas")
                        .WithMany()
                        .HasForeignKey("SzolgaltatasId");

                    b.Navigation("Szolgaltatas");
                });

            modelBuilder.Entity("Szemetszallitas.Models.Naptar", b =>
                {
                    b.HasOne("Szemetszallitas.Models.Szolgaltatas", "Szolgaltatas")
                        .WithMany()
                        .HasForeignKey("SzolgaltatasId");

                    b.Navigation("Szolgaltatas");
                });
#pragma warning restore 612, 618
        }
    }
}
