using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WeddingPlanner.Migrations
{
    public partial class Createrelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Wedplanrs");

            migrationBuilder.DropColumn(
                name: "Guests",
                table: "Wedplanrs");

            migrationBuilder.AddColumn<DateTime>(
                name: "WeddDate",
                table: "Wedplanrs",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "RSVPs",
                columns: table => new
                {
                    rsvpid = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Created_At = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Updated_At = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UserId = table.Column<int>(type: "int4", nullable: false),
                    WedplanrId = table.Column<int>(type: "int4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RSVPs", x => x.rsvpid);
                    table.ForeignKey(
                        name: "FK_RSVPs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RSVPs_Wedplanrs_WedplanrId",
                        column: x => x.WedplanrId,
                        principalTable: "Wedplanrs",
                        principalColumn: "WPId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RSVPs_UserId",
                table: "RSVPs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RSVPs_WedplanrId",
                table: "RSVPs",
                column: "WedplanrId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RSVPs");

            migrationBuilder.DropColumn(
                name: "WeddDate",
                table: "Wedplanrs");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Wedplanrs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Guests",
                table: "Wedplanrs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    GuestId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    RSVP = table.Column<bool>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.GuestId);
                });
        }
    }
}
