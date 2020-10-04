using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Royal.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Families",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Families", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vow",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vow", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Knights",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    RoyalFamilyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Knights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Knights_Families_RoyalFamilyId",
                        column: x => x.RoyalFamilyId,
                        principalTable: "Families",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vows",
                columns: table => new
                {
                    KnightId = table.Column<int>(nullable: false),
                    VowId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vows", x => new { x.KnightId, x.VowId });
                    table.ForeignKey(
                        name: "FK_Vows_Knights_KnightId",
                        column: x => x.KnightId,
                        principalTable: "Knights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vows_Vow_VowId",
                        column: x => x.VowId,
                        principalTable: "Vow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Knights_RoyalFamilyId",
                table: "Knights",
                column: "RoyalFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_Vows_VowId",
                table: "Vows",
                column: "VowId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vows");

            migrationBuilder.DropTable(
                name: "Knights");

            migrationBuilder.DropTable(
                name: "Vow");

            migrationBuilder.DropTable(
                name: "Families");
        }
    }
}
