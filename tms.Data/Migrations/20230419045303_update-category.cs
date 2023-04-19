using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tms.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatecategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Subname_AZ",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subname_EN",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subname_RU",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubofSubname_AZ",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubofSubname_EN",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubofSubname_RU",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subname_AZ",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "Subname_EN",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "Subname_RU",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "SubofSubname_AZ",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "SubofSubname_EN",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "SubofSubname_RU",
                table: "Category");
        }
    }
}
