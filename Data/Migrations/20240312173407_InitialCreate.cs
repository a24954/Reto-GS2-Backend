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
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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
                name: "Sesiones",
                columns: table => new
                {
                    IdSesion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SesionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdPlay = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sesiones", x => x.IdSesion);
                    table.ForeignKey(
                        name: "FK_Sesiones_Obras_IdPlay",
                        column: x => x.IdPlay,
                        principalTable: "Obras",
                        principalColumn: "IdPlay",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    IdReservation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserEmail = table.Column<string>(name: "User_Email", type: "nvarchar(max)", nullable: false),
                    ReservationPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdPlay = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.IdReservation);
                    table.ForeignKey(
                        name: "FK_Reservas_Obras_IdPlay",
                        column: x => x.IdPlay,
                        principalTable: "Obras",
                        principalColumn: "IdPlay",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_Usuarios_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Usuarios",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_Asientos_Sesiones_SesionIdSesion",
                        column: x => x.SesionIdSesion,
                        principalTable: "Sesiones",
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
                table: "Obras",
                columns: new[] { "IdPlay", "Description", "Name", "Photo", "Price" },
                values: new object[,]
                {
                    { 1, "Una descripción", "Lalaland", "https://picsum.photos/200/300", 100m },
                    { 2, "Otra descripción", "Los 100", "https://picsum.photos/200/300", 300m },
                    { 3, "Otra más", "Fiesta", "https://picsum.photos/200/300", 200m }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "IdUser", "Email", "Password", "Rol", "UserName" },
                values: new object[,]
                {
                    { 1, "hola1@gmail.com", "123", 0, "cosmar" },
                    { 2, "hola2@gmail.com", "123", 1, "cosmari" },
                    { 3, "hola3@gmail.com", "123", 1, "cosmaro" }
                });

            migrationBuilder.InsertData(
                table: "Reservas",
                columns: new[] { "IdReservation", "IdPlay", "IdUser", "ReservationDate", "ReservationPrice", "User_Email" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "100", "user1@example.com" },
                    { 2, 2, 2, new DateTime(2024, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "200", "user2@example.com" },
                    { 3, 3, 3, new DateTime(2024, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "300", "user3@example.com" }
                });

            migrationBuilder.InsertData(
                table: "Sesiones",
                columns: new[] { "IdSesion", "IdPlay", "SesionTime" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 3, 20, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2024, 3, 21, 10, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, new DateTime(2024, 3, 22, 20, 30, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asientos_SesionIdSesion",
                table: "Asientos",
                column: "SesionIdSesion");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_IdPlay",
                table: "Reservas",
                column: "IdPlay");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_IdUser",
                table: "Reservas",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Sesiones_IdPlay",
                table: "Sesiones",
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
                name: "Sesiones");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Obras");
        }
    }
}
