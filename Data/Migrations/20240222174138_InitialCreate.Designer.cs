﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TeatroApi.Data;

#nullable disable

namespace TeatroApi.Data.Migrations
{
    [DbContext(typeof(TeatroContext))]
    [Migration("20240222174138_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TeatroApi.Models.Asientos", b =>
                {
                    b.Property<int>("IdSeats")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSeats"));

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int?>("SesionIdSesion")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("IdSeats");

                    b.HasIndex("SesionIdSesion");

                    b.ToTable("Asientos");

                    b.HasData(
                        new
                        {
                            IdSeats = 1,
                            Number = 1,
                            Status = true
                        },
                        new
                        {
                            IdSeats = 2,
                            Number = 2,
                            Status = false
                        },
                        new
                        {
                            IdSeats = 3,
                            Number = 3,
                            Status = true
                        });
                });

            modelBuilder.Entity("TeatroApi.Models.Obra", b =>
                {
                    b.Property<int>("IdPlay")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPlay"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPlay");

                    b.ToTable("Obra");

                    b.HasData(
                        new
                        {
                            IdPlay = 1,
                            Description = "La mejor obra",
                            Name = "Lalaland",
                            Photo = "https://picsum.photos/200/300",
                            Price = "100"
                        },
                        new
                        {
                            IdPlay = 2,
                            Description = "La mejor obra",
                            Name = "Los 100",
                            Photo = "https://picsum.photos/200/300",
                            Price = "300"
                        },
                        new
                        {
                            IdPlay = 3,
                            Description = "La mejor obra",
                            Name = "Fiesta",
                            Photo = "https://picsum.photos/200/300",
                            Price = "200"
                        });
                });

            modelBuilder.Entity("TeatroApi.Models.Reserva", b =>
                {
                    b.Property<int>("IdReservation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdReservation"));

                    b.Property<int>("Id_Obra")
                        .HasColumnType("int");

                    b.Property<string>("ReservationDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReservationPrice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdReservation");

                    b.ToTable("Reserva");

                    b.HasData(
                        new
                        {
                            IdReservation = 1,
                            IdObra = 1,
                            ReservationDate = "https://picsum.photos/200/300",
                            ReservationPrice = "La mejor obra",
                            UserEmail = "Lalaland"
                        },
                        new
                        {
                            IdReservation = 2,
                            IdObra = 2,
                            ReservationDate = "https://picsum.photos/200/300",
                            ReservationPrice = "La mejor obra",
                            UserEmail = "Los 100"
                        },
                        new
                        {
                            IdReservation = 3,
                            IdObra = 3,
                            ReservationDate = "https://picsum.photos/200/300",
                            ReservationPrice = "La mejor obra",
                            UserEmail = "Fiesta"
                        });
                });

            modelBuilder.Entity("TeatroApi.Models.Sesion", b =>
                {
                    b.Property<int>("IdSesion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSesion"));

                    b.Property<DateTime>("SesionTime")
                        .HasColumnType("datetime2");

                    b.HasKey("IdSesion");

                    b.ToTable("Sesion");

                    b.HasData(
                        new
                        {
                            IdSesion = 1,
                            SesionTime = new DateTime(1, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            IdSesion = 2,
                            SesionTime = new DateTime(1, 1, 1, 10, 30, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            IdSesion = 3,
                            SesionTime = new DateTime(1, 1, 1, 20, 30, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("TeatroApi.Models.Usuario", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUser"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rol")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUser");

                    b.ToTable("Usuario");

                    b.HasData(
                        new
                        {
                            IdUser = 1,
                            Email = "hola1@gmail.com",
                            Password = "123",
                            Rol = 0,
                            UserName = "cosmar"
                        },
                        new
                        {
                            IdUser = 2,
                            Email = "hola2@gmail.com",
                            Password = "123",
                            Rol = 1,
                            UserName = "cosmari"
                        },
                        new
                        {
                            IdUser = 3,
                            Email = "hola3@gmail.com",
                            Password = "123",
                            Rol = 1,
                            UserName = "cosmaro"
                        });
                });

            modelBuilder.Entity("TeatroApi.Models.Asientos", b =>
                {
                    b.HasOne("TeatroApi.Models.Sesion", null)
                        .WithMany("Seats")
                        .HasForeignKey("SesionIdSesion");
                });

            modelBuilder.Entity("TeatroApi.Models.Sesion", b =>
                {
                    b.Navigation("Seats");
                });
#pragma warning restore 612, 618
        }
    }
}
