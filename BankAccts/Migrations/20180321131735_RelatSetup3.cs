using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BankAccts.Migrations
{
    public partial class RelatSetup3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BAcc_Users_UserId",
                table: "BAcc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BAcc",
                table: "BAcc");

            migrationBuilder.RenameTable(
                name: "BAcc",
                newName: "Baccs");

            migrationBuilder.RenameIndex(
                name: "IX_BAcc_UserId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baccs_Users_UserId",
                table: "Baccs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Baccs",
                table: "Baccs");

            migrationBuilder.RenameTable(
                name: "Baccs",
                newName: "BAcc");

            migrationBuilder.RenameIndex(
                name: "IX_Baccs_UserId",
                table: "BAcc",
                newName: "IX_BAcc_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BAcc",
                table: "BAcc",
                column: "BAccId");

            migrationBuilder.AddForeignKey(
                name: "FK_BAcc_Users_UserId",
                table: "BAcc",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
