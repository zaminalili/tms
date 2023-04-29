using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tms.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateaboutentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Abouts",
                newName: "Description_RU");

            migrationBuilder.AddColumn<string>(
                name: "Description_AZ",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description_EN",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description_AZ",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "Description_EN",
                table: "Abouts");

            migrationBuilder.RenameColumn(
                name: "Description_RU",
                table: "Abouts",
                newName: "Description");
        }
    }
}
