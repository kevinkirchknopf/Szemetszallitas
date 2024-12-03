using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Szemetszallitas.Migrations
{
    /// <inheritdoc />
    public partial class InitalCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Szolgaltatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    jelentes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Szolgaltatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lakig",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    igeny = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SzolgaltatasId = table.Column<int>(type: "int", nullable: true),
                    Szolgid = table.Column<int>(type: "int", nullable: false),
                    mennyiseg = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lakig", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lakig_Szolgaltatas_SzolgaltatasId",
                        column: x => x.SzolgaltatasId,
                        principalTable: "Szolgaltatas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Naptar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    datum = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SzolgaltatasId = table.Column<int>(type: "int", nullable: true),
                    SzolgId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Naptar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Naptar_Szolgaltatas_SzolgaltatasId",
                        column: x => x.SzolgaltatasId,
                        principalTable: "Szolgaltatas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lakig_SzolgaltatasId",
                table: "Lakig",
                column: "SzolgaltatasId");

            migrationBuilder.CreateIndex(
                name: "IX_Naptar_SzolgaltatasId",
                table: "Naptar",
                column: "SzolgaltatasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lakig");

            migrationBuilder.DropTable(
                name: "Naptar");

            migrationBuilder.DropTable(
                name: "Szolgaltatas");
        }
    }
}
