﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Prospectos.Data;

#nullable disable

namespace Prospectos.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240312110504_UpdateSchema")]
    partial class UpdateSchema
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0-preview.1.24081.2");

            modelBuilder.Entity("Prospectos.Models.DocumentoProspecto", b =>
                {
                    b.Property<int>("nDocumentoProspecto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("bActivo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("cDocumento")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("nProspecto")
                        .HasColumnType("INTEGER");

                    b.HasKey("nDocumentoProspecto");

                    b.ToTable("DocumentosProspectos");
                });

            modelBuilder.Entity("Prospectos.Models.Estatus", b =>
                {
                    b.Property<int>("nEstatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("bActivo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("cEstatus")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("nEstatus");

                    b.ToTable("Estatus");
                });

            modelBuilder.Entity("Prospectos.Models.Prospecto", b =>
                {
                    b.Property<int>("nProspecto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("bActivo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("cApellidoMaterno")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("cApellidoPaterno")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("cCalle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("cCodigoPostal")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("cColonia")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("cNoExt")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("cNombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("cRFC")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("cTelefono")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("nEstatus")
                        .HasColumnType("INTEGER");

                    b.HasKey("nProspecto");

                    b.HasIndex("nEstatus")
                        .IsUnique();

                    b.ToTable("Prospectos");
                });

            modelBuilder.Entity("Prospectos.Models.Prospecto", b =>
                {
                    b.HasOne("Prospectos.Models.Estatus", "Estatus")
                        .WithOne("Prospecto")
                        .HasForeignKey("Prospectos.Models.Prospecto", "nEstatus")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estatus");
                });

            modelBuilder.Entity("Prospectos.Models.Estatus", b =>
                {
                    b.Navigation("Prospecto");
                });
#pragma warning restore 612, 618
        }
    }
}