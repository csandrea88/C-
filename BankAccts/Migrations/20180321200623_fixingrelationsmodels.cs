using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BankAccts.Migrations
{
    public partial class fixingrelationsmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baccs_Users_UserId",
                table: "Baccs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Baccs",
                table: "Baccs");

            migrationBuilder.RenameTable(
                name: "Baccs",
                newName: "BAccs");

            migrationBuilder.RenameIndex(
                name: "IX_Baccs_UserId",
                table: "BAccs",
                newName: "IX_BAccs_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BAccs",
                table: "BAccs",
                column: "BAccId");

            migrationBuilder.AddForeignKey(
                name: "FK_BAccs_Users_UserId",
                table: "BAccs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BAccs_Users_UserId",
                table: "BAccs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BAccs",
                table: "BAccs");

            migrationBuilder.RenameTable(
                name: "BAccs",
                newName: "Baccs");

            migrationBuilder.RenameIndex(
                name: "IX_BAccs_UserId",
                table: "Baccs",
                newName: "IX_Baccs_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Baccs",
                table: "Baccs",
                column: "BAccId");

            migrationBuilder.AddForeignKey(
                name: "FK_Baccs_Users_UserId",
                table: "Baccs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
