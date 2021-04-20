using Microsoft.EntityFrameworkCore.Migrations;

namespace EgyGuide.DataAccess.Migrations
{
    public partial class addinformationToRequested : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RequestedInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TripId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestedInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestedRequestedInfo",
                columns: table => new
                {
                    RequestedInfoId = table.Column<int>(type: "int", nullable: false),
                    RequestedTripId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestedRequestedInfo", x => new { x.RequestedInfoId, x.RequestedTripId });
                    table.ForeignKey(
                        name: "FK_RequestedRequestedInfo_Requested_RequestedTripId",
                        column: x => x.RequestedTripId,
                        principalTable: "Requested",
                        principalColumn: "TripId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestedRequestedInfo_RequestedInfo_RequestedInfoId",
                        column: x => x.RequestedInfoId,
                        principalTable: "RequestedInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestedRequestedInfo_RequestedTripId",
                table: "RequestedRequestedInfo",
                column: "RequestedTripId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestedRequestedInfo");

            migrationBuilder.DropTable(
                name: "RequestedInfo");
        }
    }
}
