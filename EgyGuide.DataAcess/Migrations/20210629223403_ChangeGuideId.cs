using Microsoft.EntityFrameworkCore.Migrations;

namespace EgyGuide.DataAccess.Migrations
{
    public partial class ChangeGuideId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TripDetails_AspNetUsers_GuideId",
                table: "TripDetails");

            migrationBuilder.AlterColumn<int>(
                name: "GuideId",
                table: "TripDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TripDetails_GuideUsers_GuideId",
                table: "TripDetails",
                column: "GuideId",
                principalTable: "GuideUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TripDetails_GuideUsers_GuideId",
                table: "TripDetails");

            migrationBuilder.AlterColumn<string>(
                name: "GuideId",
                table: "TripDetails",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TripDetails_AspNetUsers_GuideId",
                table: "TripDetails",
                column: "GuideId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
