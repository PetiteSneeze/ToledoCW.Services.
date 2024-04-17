using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToledoCW.Services.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class atendenteforeignkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Estabelecimento",
                table: "atendente",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_atendente_Estabelecimento",
                table: "atendente",
                column: "Estabelecimento");

            migrationBuilder.AddForeignKey(
                name: "FK_atendente_estabelecimento_Estabelecimento",
                table: "atendente",
                column: "Estabelecimento",
                principalTable: "estabelecimento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_atendente_estabelecimento_Estabelecimento",
                table: "atendente");

            migrationBuilder.DropIndex(
                name: "IX_atendente_Estabelecimento",
                table: "atendente");

            migrationBuilder.DropColumn(
                name: "Estabelecimento",
                table: "atendente");
        }
    }
}
