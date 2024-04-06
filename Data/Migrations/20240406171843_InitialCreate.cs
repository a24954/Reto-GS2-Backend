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
                name: "Obras",
                columns: table => new
                {
                    IdPlay = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obras", x => x.IdPlay);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
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
                    table.PrimaryKey("PK_Usuarios", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    IdReservation = table.Column<int>(type: "int", nullable: false),
                    IdPlay = table.Column<int>(type: "int", nullable: false),
                    UserEmail = table.Column<string>(name: "User_Email", type: "nvarchar(max)", nullable: false),
                    ReservationPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => new { x.IdReservation, x.IdPlay });
                    table.ForeignKey(
                        name: "FK_Reservas_Obras_IdPlay",
                        column: x => x.IdPlay,
                        principalTable: "Obras",
                        principalColumn: "IdPlay",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sesiones",
                columns: table => new
                {
                    IdSesion = table.Column<int>(type: "int", nullable: false),
                    IdSeats = table.Column<int>(type: "int", nullable: false),
                    SesionTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdPlay = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sesiones", x => new { x.IdSesion, x.IdSeats });
                    table.ForeignKey(
                        name: "FK_Sesiones_Obras_IdSesion",
                        column: x => x.IdSesion,
                        principalTable: "Obras",
                        principalColumn: "IdPlay",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Asientos",
                columns: table => new
                {
                    IdSeats = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    IdSesion = table.Column<int>(type: "int", nullable: false),
                    SesionIdSeats = table.Column<int>(type: "int", nullable: true),
                    SesionIdSesion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asientos", x => new { x.IdSeats, x.IdUser });
                    table.ForeignKey(
                        name: "FK_Asientos_Sesiones_SesionIdSesion_SesionIdSeats",
                        columns: x => new { x.SesionIdSesion, x.SesionIdSeats },
                        principalTable: "Sesiones",
                        principalColumns: new[] { "IdSesion", "IdSeats" });
                });

            migrationBuilder.InsertData(
                table: "Asientos",
                columns: new[] { "IdSeats", "IdUser", "IdSesion", "Number", "SesionIdSeats", "SesionIdSesion", "Status" },
                values: new object[,]
                {
                    { 1, 0, 0, 1, null, null, true },
                    { 2, 0, 0, 2, null, null, false },
                    { 3, 0, 0, 3, null, null, true }
                });

            migrationBuilder.InsertData(
                table: "Obras",
                columns: new[] { "IdPlay", "Date", "Description", "Duration", "Name", "Photo", "Price" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Una descripción", "2h", "Lalaland", "https://picsum.photos/200/300", 100m },
                    { 2, new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Otra descripción", "2h", "Los 100", "https://picsum.photos/200/300", 300m },
                    { 3, new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Otra más", "2h", "Fiesta", "https://picsum.photos/200/300", 200m }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "IdUser", "Email", "Password", "Rol", "UserName" },
                values: new object[,]
                {
                    { 1, "hola1@gmail.com", "123", 1, "cosmar" },
                    { 2, "hola2@gmail.com", "123", 2, "cosmari" },
                    { 3, "hola3@gmail.com", "123", 2, "cosmaro" }
                });

            migrationBuilder.InsertData(
                table: "Reservas",
                columns: new[] { "IdPlay", "IdReservation", "IdUser", "ReservationDate", "ReservationPrice", "User_Email" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "100", "user1@example.com" },
                    { 1, 2, 2, new DateTime(2024, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "200", "user2@example.com" },
                    { 1, 3, 3, new DateTime(2024, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "300", "user3@example.com" }
                });

            migrationBuilder.InsertData(
                table: "Sesiones",
                columns: new[] { "IdSeats", "IdSesion", "IdPlay", "SesionTime" },
                values: new object[,]
                {
                    { 1, 1, 1, "16:00-17:00" },
                    { 2, 2, 2, "19:00-20:00" },
                    { 3, 3, 3, "22:00-23:00" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asientos_SesionIdSesion_SesionIdSeats",
                table: "Asientos",
                columns: new[] { "SesionIdSesion", "SesionIdSeats" });

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_IdPlay",
                table: "Reservas",
                column: "IdPlay");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asientos");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Sesiones");

            migrationBuilder.DropTable(
                name: "Obras");
        }
    }
}
