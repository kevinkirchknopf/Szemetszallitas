using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Szemetszallitas.Migrations
{
    /// <inheritdoc />
    public partial class Migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Naptar_Szolgaltatas_SzolgaltatasId",
                table: "Naptar");

            migrationBuilder.DropIndex(
                name: "IX_Naptar_SzolgaltatasId",
                table: "Naptar");

            migrationBuilder.DropColumn(
                name: "SzolgaltatasId",
                table: "Naptar");

            migrationBuilder.CreateIndex(
                name: "IX_Naptar_SzolgId",
                table: "Naptar",
                column: "SzolgId");

            migrationBuilder.AddForeignKey(
                name: "FK_Naptar_Szolgaltatas_SzolgId",
                table: "Naptar",
                column: "SzolgId",
                principalTable: "Szolgaltatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Naptar_Szolgaltatas_SzolgId",
                table: "Naptar");

            migrationBuilder.DropIndex(
                name: "IX_Naptar_SzolgId",
                table: "Naptar");

            migrationBuilder.AddColumn<int>(
                name: "SzolgaltatasId",
                table: "Naptar",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Naptar_SzolgaltatasId",
                table: "Naptar",
                column: "SzolgaltatasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Naptar_Szolgaltatas_SzolgaltatasId",
                table: "Naptar",
                column: "SzolgaltatasId",
                principalTable: "Szolgaltatas",
                principalColumn: "Id");
        }
    }
}
