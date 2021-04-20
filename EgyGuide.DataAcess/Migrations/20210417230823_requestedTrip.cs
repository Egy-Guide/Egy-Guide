using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EgyGuide.DataAccess.Migrations
{
    public partial class requestedTrip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Requested",
                columns: table => new
                {
                    TripId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Budget = table.Column<float>(type: "real", nullable: false),
                    Days = table.Column<int>(type: "int", nullable: false),
                    Nights = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Transport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeetingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    SelcetedStyles = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SelectedLanguages = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumTravellers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requested", x => x.TripId);
                    table.ForeignKey(
                        name: "FK_Requested_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestedSelectedStyle",
                columns: table => new
                {
                    SelectedStyleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StyleId = table.Column<int>(type: "int", nullable: false),
                    TripStyleStyleId = table.Column<int>(type: "int", nullable: true),
                    TripId = table.Column<int>(type: "int", nullable: false),
                    RequestedTripId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestedSelectedStyle", x => x.SelectedStyleId);
                    table.ForeignKey(
                        name: "FK_RequestedSelectedStyle_Requested_RequestedTripId",
                        column: x => x.RequestedTripId,
                        principalTable: "Requested",
                        principalColumn: "TripId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RequestedSelectedStyle_TripStyles_TripStyleStyleId",
                        column: x => x.TripStyleStyleId,
                        principalTable: "TripStyles",
                        principalColumn: "StyleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requested_CityId",
                table: "Requested",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestedSelectedStyle_RequestedTripId",
                table: "RequestedSelectedStyle",
                column: "RequestedTripId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestedSelectedStyle_TripStyleStyleId",
                table: "RequestedSelectedStyle",
                column: "TripStyleStyleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestedSelectedStyle");

            migrationBuilder.DropTable(
                name: "Requested");
        }
    }
}
