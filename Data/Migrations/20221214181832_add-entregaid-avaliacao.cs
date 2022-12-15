using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class addentregaidavaliacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entrega_Avaliacao_AvaliacaoId",
                table: "Entrega");

            migrationBuilder.DropIndex(
                name: "IX_Entrega_AvaliacaoId",
                table: "Entrega");

            migrationBuilder.DropColumn(
                name: "AvaliacaoId",
                table: "Entrega");

            migrationBuilder.AddColumn<int>(
                name: "EntregaId",
                table: "Avaliacao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_EntregaId",
                table: "Avaliacao",
                column: "EntregaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacao_Entrega_EntregaId",
                table: "Avaliacao",
                column: "EntregaId",
                principalTable: "Entrega",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacao_Entrega_EntregaId",
                table: "Avaliacao");

            migrationBuilder.DropIndex(
                name: "IX_Avaliacao_EntregaId",
                table: "Avaliacao");

            migrationBuilder.DropColumn(
                name: "EntregaId",
                table: "Avaliacao");

            migrationBuilder.AddColumn<int>(
                name: "AvaliacaoId",
                table: "Entrega",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entrega_AvaliacaoId",
                table: "Entrega",
                column: "AvaliacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrega_Avaliacao_AvaliacaoId",
                table: "Entrega",
                column: "AvaliacaoId",
                principalTable: "Avaliacao",
                principalColumn: "Id");
        }
    }
}
