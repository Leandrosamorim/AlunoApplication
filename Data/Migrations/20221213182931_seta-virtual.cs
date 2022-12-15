using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class setavirtual : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Entrega_TarefaId",
                table: "Entrega");

            migrationBuilder.CreateIndex(
                name: "IX_Entrega_TarefaId",
                table: "Entrega",
                column: "TarefaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Entrega_TarefaId",
                table: "Entrega");

            migrationBuilder.CreateIndex(
                name: "IX_Entrega_TarefaId",
                table: "Entrega",
                column: "TarefaId",
                unique: true);
        }
    }
}
