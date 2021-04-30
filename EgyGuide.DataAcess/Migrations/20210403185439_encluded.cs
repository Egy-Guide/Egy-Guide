using Microsoft.EntityFrameworkCore.Migrations;

namespace EgyGuide.DataAccess.Migrations
{
    public partial class encluded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExcludedTripDetail_Excluded_ExcludedId",
                table: "ExcludedTripDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_IncludedTripDetail_Included_IncludedId",
                table: "IncludedTripDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Included",
                table: "Included");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Excluded",
                table: "Excluded");

            migrationBuilder.RenameTable(
                name: "Included",
                newName: "Includeds");

            migrationBuilder.RenameTable(
                name: "Excluded",
                newName: "Excludeds");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Includeds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Excludeds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Includeds",
                table: "Includeds",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Excludeds",
                table: "Excludeds",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExcludedTripDetail_Excludeds_ExcludedId",
                table: "ExcludedTripDetail",
                column: "ExcludedId",
                principalTable: "Excludeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IncludedTripDetail_Includeds_IncludedId",
                table: "IncludedTripDetail",
                column: "IncludedId",
                principalTable: "Includeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExcludedTripDetail_Excludeds_ExcludedId",
                table: "ExcludedTripDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_IncludedTripDetail_Includeds_IncludedId",
                table: "IncludedTripDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Includeds",
                table: "Includeds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Excludeds",
                table: "Excludeds");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Includeds");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Excludeds");

            migrationBuilder.RenameTable(
                name: "Includeds",
                newName: "Included");

            migrationBuilder.RenameTable(
                name: "Excludeds",
                newName: "Excluded");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Included",
                table: "Included",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Excluded",
                table: "Excluded",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExcludedTripDetail_Excluded_ExcludedId",
                table: "ExcludedTripDetail",
                column: "ExcludedId",
                principalTable: "Excluded",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IncludedTripDetail_Included_IncludedId",
                table: "IncludedTripDetail",
                column: "IncludedId",
                principalTable: "Included",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
