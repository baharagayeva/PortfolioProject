using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class migWorkCategoryID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "idx_Portfolio_CategoryID_Title_Deleted",
                table: "Portfolios");

            migrationBuilder.DropIndex(
                name: "IX_Portfolios_WorkCategoryID",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Portfolios");

            migrationBuilder.CreateIndex(
                name: "idx_Portfolio_WorkCategoryID_Title_Deleted",
                table: "Portfolios",
                columns: new[] { "WorkCategoryID", "Title", "Deleted" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "idx_Portfolio_WorkCategoryID_Title_Deleted",
                table: "Portfolios");

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Portfolios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "idx_Portfolio_CategoryID_Title_Deleted",
                table: "Portfolios",
                columns: new[] { "CategoryID", "Title", "Deleted" });

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_WorkCategoryID",
                table: "Portfolios",
                column: "WorkCategoryID");
        }
    }
}
