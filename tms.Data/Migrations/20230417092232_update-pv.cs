﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tms.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatepv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "PK_PriceViews",
                table: "PriceViews",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PriceViews",
                table: "PriceViews");
        }
    }
}
