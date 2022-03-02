using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTheaterReservations.Data.Migrations
{
    public partial class DropReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Reservations_ReservationId",
                table: "Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Reservations_ReservationId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ReservationId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Seats_ReservationId",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Seats");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "Tickets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "Seats",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieShowingId = table.Column<int>(type: "int", nullable: false),
                    ContactInformation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfTickets = table.Column<int>(type: "int", nullable: false),
                    ReservationContactType = table.Column<int>(type: "int", nullable: false),
                    ReservationType = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_MoviesShowings_MovieShowingId",
                        column: x => x.MovieShowingId,
                        principalTable: "MoviesShowings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ReservationId",
                table: "Tickets",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_ReservationId",
                table: "Seats",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_MovieShowingId",
                table: "Reservations",
                column: "MovieShowingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Reservations_ReservationId",
                table: "Seats",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Reservations_ReservationId",
                table: "Tickets",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id");
        }
    }
}
