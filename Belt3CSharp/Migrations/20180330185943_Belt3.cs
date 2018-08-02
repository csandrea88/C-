using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Belt3CSharp.Migrations
{
    public partial class Belt3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    FName = table.Column<string>(type: "text", nullable: true),
                    LName = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Userint1 = table.Column<int>(type: "int4", nullable: false),
                    Userstrg1 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Belt3s",
                columns: table => new
                {
                    Belt3Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Belt3date = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Belt3int1 = table.Column<int>(type: "int4", nullable: false),
                    Belt3int2 = table.Column<int>(type: "int4", nullable: false),
                    Belt3stg1 = table.Column<string>(type: "text", nullable: true),
                    Belt3stg2 = table.Column<string>(type: "text", nullable: true),
                    Belt3stg3 = table.Column<string>(type: "text", nullable: true),
                    Belt3stg4 = table.Column<string>(type: "text", nullable: true),
                    Belt3stg5 = table.Column<string>(type: "text", nullable: true),
                    Created_At = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Updated_At = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UserId = table.Column<int>(type: "int4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Belt3s", x => x.Belt3Id);
                    table.ForeignKey(
                        name: "FK_Belt3s_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MtoMs",
                columns: table => new
                {
                    MtoMId = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Belt3Id = table.Column<int>(type: "int4", nullable: false),
                    Created_At = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Updated_At = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Userid = table.Column<int>(type: "int4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MtoMs", x => x.MtoMId);
                    table.ForeignKey(
                        name: "FK_MtoMs_Belt3s_Belt3Id",
                        column: x => x.Belt3Id,
                        principalTable: "Belt3s",
                        principalColumn: "Belt3Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MtoMs_Users_Userid",
                        column: x => x.Userid,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Belt3s_UserId",
                table: "Belt3s",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MtoMs_Belt3Id",
                table: "MtoMs",
                column: "Belt3Id");

            migrationBuilder.CreateIndex(
                name: "IX_MtoMs_Userid",
                table: "MtoMs",
                column: "Userid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MtoMs");

            migrationBuilder.DropTable(
                name: "Belt3s");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
