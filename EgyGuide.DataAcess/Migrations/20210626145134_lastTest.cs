using Microsoft.EntityFrameworkCore.Migrations;

namespace EgyGuide.DataAccess.Migrations
{
    public partial class lastTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Galleries_TripDetails_TripDetailTripId",
                table: "Galleries");

            migrationBuilder.DropIndex(
                name: "IX_Galleries_TripDetailTripId",
                table: "Galleries");

            migrationBuilder.DropColumn(
                name: "TripDetailTripId",
                table: "Galleries");

            migrationBuilder.CreateTable(
                name: "GalleryTripDetail",
                columns: table => new
                {
                    SelectedImagesId = table.Column<int>(type: "int", nullable: false),
                    TripDetailsTripId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GalleryTripDetail", x => new { x.SelectedImagesId, x.TripDetailsTripId });
                    table.ForeignKey(
                        name: "FK_GalleryTripDetail_Galleries_SelectedImagesId",
                        column: x => x.SelectedImagesId,
                        principalTable: "Galleries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GalleryTripDetail_TripDetails_TripDetailsTripId",
                        column: x => x.TripDetailsTripId,
                        principalTable: "TripDetails",
                        principalColumn: "TripId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GalleryTripDetail_TripDetailsTripId",
                table: "GalleryTripDetail",
                column: "TripDetailsTripId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GalleryTripDetail");

            migrationBuilder.AddColumn<int>(
                name: "TripDetailTripId",
                table: "Galleries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Galleries_TripDetailTripId",
                table: "Galleries",
                column: "TripDetailTripId");

            migrationBuilder.AddForeignKey(
                name: "FK_Galleries_TripDetails_TripDetailTripId",
                table: "Galleries",
                column: "TripDetailTripId",
                principalTable: "TripDetails",
                principalColumn: "TripId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
