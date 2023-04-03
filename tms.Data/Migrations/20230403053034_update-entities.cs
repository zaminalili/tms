using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tms.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateentities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "About_AZ",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "About_EN",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "About_RU",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country_AZ",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country_EN",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country_RU",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description_AZ",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description_EN",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description_RU",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title_AZ",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title_EN",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title_RU",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name_AZ",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name_EN",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name_RU",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "About_AZ",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "About_EN",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "About_RU",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Country_AZ",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Country_EN",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Country_RU",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Description_AZ",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "Description_EN",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "Description_RU",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "Title_AZ",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "Title_EN",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "Title_RU",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "Name_AZ",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "Name_EN",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "Name_RU",
                table: "Category");
        }
    }
}
