using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WeddingPlanner.Migrations
{
    public partial class CreateGuestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Wedplanrs",
                table: "Wedplanrs");

            migrationBuilder.RenameTable(
                name: "Wedplanrs",
                newName: "WedPlanr");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WedPlanr",
                table: "WedPlanr",
                column: "WPId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WedPlanr",
                table: "WedPlanr");

            migrationBuilder.RenameTable(
                name: "WedPlanr",
                newName: "Wedplanrs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wedplanrs",
                table: "Wedplanrs",
                column: "WPId");
        }
    }
}
