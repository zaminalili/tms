﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tms.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatepriceview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PriceViews",
                table: "PriceViews");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "PriceViews",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "PriceViews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "PriceViews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "PriceViews",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "PriceViews",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EditedBy",
                table: "PriceViews",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EditedDate",
                table: "PriceViews",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PriceViews",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PriceViews");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "PriceViews");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "PriceViews");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "PriceViews");

            migrationBuilder.DropColumn(
                name: "EditedBy",
                table: "PriceViews");

            migrationBuilder.DropColumn(
                name: "EditedDate",
                table: "PriceViews");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PriceViews");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PriceViews",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PriceViews",
                table: "PriceViews",
                column: "id");
        }
    }
}
