﻿// <auto-generated />
using System;
using FotoDB.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FotoDB.Migrations
{
    [DbContext(typeof(FotoContext))]
    partial class FotoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FotoDB.Models.AutorModel", b =>
                {
                    b.Property<int>("AutorModelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KrajModelID")
                        .HasColumnType("int");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AutorModelID");

                    b.HasIndex("KrajModelID");

                    b.ToTable("Autors");
                });

            modelBuilder.Entity("FotoDB.Models.FotoModel", b =>
                {
                    b.Property<int>("FotoModelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AutorModelID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataWykonania")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("FotoData")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("FotoRozszerzenie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FotoTytul")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FotoModelID");

                    b.HasIndex("AutorModelID");

                    b.ToTable("Fotos");
                });

            modelBuilder.Entity("FotoDB.Models.KrajModel", b =>
                {
                    b.Property<int>("KrajModelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KrajModelID");

                    b.ToTable("Krajs");
                });

            modelBuilder.Entity("FotoDB.Models.AutorModel", b =>
                {
                    b.HasOne("FotoDB.Models.KrajModel", "KrajModel")
                        .WithMany()
                        .HasForeignKey("KrajModelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KrajModel");
                });

            modelBuilder.Entity("FotoDB.Models.FotoModel", b =>
                {
                    b.HasOne("FotoDB.Models.AutorModel", "AutorModel")
                        .WithMany()
                        .HasForeignKey("AutorModelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AutorModel");
                });
#pragma warning restore 612, 618
        }
    }
}