﻿// <auto-generated />
using System;
using ApiRestaurante.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiRestaurante.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240716063406_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApiRestaurante.Core.Domain.Entities.Ingrediente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ingredientes", (string)null);
                });

            modelBuilder.Entity("ApiRestaurante.Core.Domain.Entities.Mesa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CantidadPersonas")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Mesas", (string)null);
                });

            modelBuilder.Entity("ApiRestaurante.Core.Domain.Entities.Orden", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MesaId")
                        .HasColumnType("int");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("MesaId");

                    b.ToTable("Ordenes", (string)null);
                });

            modelBuilder.Entity("ApiRestaurante.Core.Domain.Entities.Plato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CantidadPersonas")
                        .HasColumnType("int");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrdenId")
                        .HasColumnType("int");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("OrdenId");

                    b.ToTable("Platos", (string)null);
                });

            modelBuilder.Entity("IngredientePlato", b =>
                {
                    b.Property<int>("IngredientesId")
                        .HasColumnType("int");

                    b.Property<int>("PlatosId")
                        .HasColumnType("int");

                    b.HasKey("IngredientesId", "PlatosId");

                    b.HasIndex("PlatosId");

                    b.ToTable("IngredientePlato");
                });

            modelBuilder.Entity("ApiRestaurante.Core.Domain.Entities.Orden", b =>
                {
                    b.HasOne("ApiRestaurante.Core.Domain.Entities.Mesa", "Mesa")
                        .WithMany("Ordenes")
                        .HasForeignKey("MesaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mesa");
                });

            modelBuilder.Entity("ApiRestaurante.Core.Domain.Entities.Plato", b =>
                {
                    b.HasOne("ApiRestaurante.Core.Domain.Entities.Orden", null)
                        .WithMany("Platos")
                        .HasForeignKey("OrdenId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IngredientePlato", b =>
                {
                    b.HasOne("ApiRestaurante.Core.Domain.Entities.Ingrediente", null)
                        .WithMany()
                        .HasForeignKey("IngredientesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiRestaurante.Core.Domain.Entities.Plato", null)
                        .WithMany()
                        .HasForeignKey("PlatosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ApiRestaurante.Core.Domain.Entities.Mesa", b =>
                {
                    b.Navigation("Ordenes");
                });

            modelBuilder.Entity("ApiRestaurante.Core.Domain.Entities.Orden", b =>
                {
                    b.Navigation("Platos");
                });
#pragma warning restore 612, 618
        }
    }
}
