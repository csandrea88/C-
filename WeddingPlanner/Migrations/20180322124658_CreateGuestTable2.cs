using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WeddingPlanner.Migrations
{
    public partial class CreateGuestTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    GuestId = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    RSVP = table.Column<bool>(type: "bool", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.GuestId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Guests");

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
    }
}
