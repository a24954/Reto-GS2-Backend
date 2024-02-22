using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TeatroApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Obra",
                columns: table => new
                {
                    IdPlay = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obra", x => x.IdPlay);
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    IdReservation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserEmail = table.Column<string>(name: "User_Email", type: "nvarchar(max)", nullable: false),
                    ReservationPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReservationDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdObra = table.Column<int>(name: "Id_Obra", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.IdReservation);
                });

            migrationBuilder.CreateTable(
                name: "Sesion",
                columns: table => new
                {
                    IdSesion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SesionTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sesion", x => x.IdSesion);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "Asientos",
                columns: table => new
                {
                    IdSeats = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    SesionIdSesion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asientos", x => x.IdSeats);
                    table.ForeignKey(
                        name: "FK_Asientos_Sesion_SesionIdSesion",
                        column: x => x.SesionIdSesion,
                        principalTable: "Sesion",
                        principalColumn: "IdSesion");
                });

            migrationBuilder.InsertData(
                table: "Asientos",
                columns: new[] { "IdSeats", "Number", "SesionIdSesion", "Status" },
                values: new object[,]
                {
                    { 1, 1, null, true },
                    { 2, 2, null, false },
                    { 3, 3, null, true }
                });

            migrationBuilder.InsertData(
                table: "Obra",
                columns: new[] { "IdPlay", "Description", "Name", "Photo", "Price" },
                values: new object[,]
                {
                    { 1, "La mejor obra", "Lalaland", "https://picsum.photos/200/300", "100" },
                    { 2, "La mejor obra", "Los 100", "https://picsum.photos/200/300", "300" },
                    { 3, "La mejor obra", "Fiesta", "https://picsum.photos/200/300", "200" }
                });

            migrationBuilder.InsertData(
                table: "Reserva",
                columns: new[] { "IdReservation", "Id_Obra", "ReservationDate", "ReservationPrice", "User_Email" },
                values: new object[,]
                {
                    { 1, 1, "https://picsum.photos/200/300", "La mejor obra", "Lalaland" },
                    { 2, 2, "https://picsum.photos/200/300", "La mejor obra", "Los 100" },
                    { 3, 3, "https://picsum.photos/200/300", "La mejor obra", "Fiesta" }
                });

            migrationBuilder.InsertData(
                table: "Sesion",
                columns: new[] { "IdSesion", "SesionTime" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1, 1, 1, 10, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(1, 1, 1, 20, 30, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "IdUser", "Email", "Password", "Rol", "UserName" },
                values: new object[,]
                {
                    { 1, "hola1@gmail.com", "123", 0, "cosmar" },
                    { 2, "hola2@gmail.com", "123", 1, "cosmari" },
                    { 3, "hola3@gmail.com", "123", 1, "cosmaro" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asientos_SesionIdSesion",
                table: "Asientos",
                column: "SesionIdSesion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asientos");

            migrationBuilder.DropTable(
                name: "Obra");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Sesion");
        }
    }
}
