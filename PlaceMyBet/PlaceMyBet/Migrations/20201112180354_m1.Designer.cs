﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlaceMyBet.Models;

namespace PlaceMyBet.Migrations
{
    [DbContext(typeof(PlaceMyBetContext))]
    [Migration("20201112180354_m1")]
    partial class m1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PlaceMyBet.Models.Apuesta", b =>
                {
                    b.Property<int>("ApuestaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("Cuota")
                        .HasColumnType("double");

                    b.Property<double>("DineroApostado")
                        .HasColumnType("double");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("MercadoId")
                        .HasColumnType("int");

                    b.Property<double>("TipoMercado")
                        .HasColumnType("double");

                    b.Property<string>("TipoOverUnder")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("ApuestaId");

                    b.HasIndex("MercadoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Apuestas");

                    b.HasData(
                        new
                        {
                            ApuestaId = 1,
                            Cuota = 10.0,
                            DineroApostado = 1000.0,
                            Fecha = new DateTime(2020, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MercadoId = 1,
                            TipoMercado = 1.5,
                            TipoOverUnder = "Over",
                            UsuarioId = "jolame@floridauniversitaria.es"
                        });
                });

            modelBuilder.Entity("PlaceMyBet.Models.Cuenta", b =>
                {
                    b.Property<int>("CuentaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NombreBanco")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<double>("Saldo")
                        .HasColumnType("double");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("CuentaId");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("Cuentas");

                    b.HasData(
                        new
                        {
                            CuentaId = 1,
                            NombreBanco = "Bankia",
                            Saldo = 2500.0,
                            UsuarioId = "jolame@floridauniversitaria.es"
                        });
                });

            modelBuilder.Entity("PlaceMyBet.Models.Evento", b =>
                {
                    b.Property<int>("EventoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("EquipoLocal")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("EquipoVisitante")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime(6)");

                    b.HasKey("EventoId");

                    b.ToTable("Eventos");

                    b.HasData(
                        new
                        {
                            EventoId = 1,
                            EquipoLocal = "Valencia",
                            EquipoVisitante = "Espanyol",
                            Fecha = new DateTime(2020, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("PlaceMyBet.Models.Mercado", b =>
                {
                    b.Property<int>("MercadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("CuotaOver")
                        .HasColumnType("double");

                    b.Property<double>("CuotaUnder")
                        .HasColumnType("double");

                    b.Property<double>("DineroOver")
                        .HasColumnType("double");

                    b.Property<double>("DineroUnder")
                        .HasColumnType("double");

                    b.Property<int>("EventoId")
                        .HasColumnType("int");

                    b.Property<double>("TipoMercado")
                        .HasColumnType("double");

                    b.HasKey("MercadoId");

                    b.HasIndex("EventoId");

                    b.ToTable("Mercados");

                    b.HasData(
                        new
                        {
                            MercadoId = 1,
                            CuotaOver = 1.4299999999999999,
                            CuotaUnder = 2.8500000000000001,
                            DineroOver = 100.0,
                            DineroUnder = 50.0,
                            EventoId = 1,
                            TipoMercado = 1.5
                        },
                        new
                        {
                            MercadoId = 2,
                            CuotaOver = 1.8999999999999999,
                            CuotaUnder = 1.8999999999999999,
                            DineroOver = 100.0,
                            DineroUnder = 100.0,
                            EventoId = 1,
                            TipoMercado = 2.5
                        },
                        new
                        {
                            MercadoId = 3,
                            CuotaOver = 2.8500000000000001,
                            CuotaUnder = 1.4299999999999999,
                            DineroOver = 50.0,
                            DineroUnder = 100.0,
                            EventoId = 1,
                            TipoMercado = 3.5
                        });
                });

            modelBuilder.Entity("PlaceMyBet.Models.Usuario", b =>
                {
                    b.Property<string>("UsuarioId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Apellidos")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            UsuarioId = "jolame@floridauniversitaria.es",
                            Apellidos = "Lacueva",
                            Edad = 21,
                            Nombre = "Jose"
                        });
                });

            modelBuilder.Entity("PlaceMyBet.Models.Apuesta", b =>
                {
                    b.HasOne("PlaceMyBet.Models.Mercado", "Mercado")
                        .WithMany()
                        .HasForeignKey("MercadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlaceMyBet.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("PlaceMyBet.Models.Cuenta", b =>
                {
                    b.HasOne("PlaceMyBet.Models.Usuario", "Usuario")
                        .WithOne("Cuenta")
                        .HasForeignKey("PlaceMyBet.Models.Cuenta", "UsuarioId");
                });

            modelBuilder.Entity("PlaceMyBet.Models.Mercado", b =>
                {
                    b.HasOne("PlaceMyBet.Models.Evento", "Evento")
                        .WithMany("Mercados")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
