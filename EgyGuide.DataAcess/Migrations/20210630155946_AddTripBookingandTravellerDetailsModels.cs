using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EgyGuide.DataAccess.Migrations
{
    public partial class AddTripBookingandTravellerDetailsModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TripBookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TripId = table.Column<int>(type: "int", nullable: false),
                    TouristId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BookingNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TripStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TripEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoTravellers = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripBookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_TripBookings_AspNetUsers_TouristId",
                        column: x => x.TouristId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TripBookings_TripDetails_TripId",
                        column: x => x.TripId,
                        principalTable: "TripDetails",
                        principalColumn: "TripId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TravellersDetails",
                columns: table => new
                {
                    TravellerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravellersDetails", x => x.TravellerId);
                    table.ForeignKey(
                        name: "FK_TravellersDetails_TripBookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "TripBookings",
                        principalColumn: "BookingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TravellersDetails_BookingId",
                table: "TravellersDetails",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_TripBookings_TouristId",
                table: "TripBookings",
                column: "TouristId");

            migrationBuilder.CreateIndex(
                name: "IX_TripBookings_TripId",
                table: "TripBookings",
                column: "TripId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TravellersDetails");

            migrationBuilder.DropTable(
                name: "TripBookings");
        }
    }
}
