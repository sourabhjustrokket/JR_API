using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace JR_API.Migrations
{
    public partial class foreignkey_question_new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Users_userId",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Questions",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_userId",
                table: "Questions",
                newName: "IX_Questions_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Questions",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Users_UserId",
                table: "Questions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Users_UserId",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Questions",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_UserId",
                table: "Questions",
                newName: "IX_Questions_userId");

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "Questions",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Users_userId",
                table: "Questions",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
