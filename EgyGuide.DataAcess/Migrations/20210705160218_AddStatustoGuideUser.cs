using Microsoft.EntityFrameworkCore.Migrations;

namespace EgyGuide.DataAccess.Migrations
{
    public partial class AddStatustoGuideUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "GuideUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "GuideUsers");
        }
    }
}
