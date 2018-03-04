using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace JR_API.Migrations
{
    public partial class Tag_TagTypeRemoved_TagIsActiveAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TagTypeId",
                table: "Tags");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Tags",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Tags");

            migrationBuilder.AddColumn<int>(
                name: "TagTypeId",
                table: "Tags",
                nullable: false,
                defaultValue: 0);
        }
    }
}
