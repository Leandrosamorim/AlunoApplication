using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class corrigenome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atraso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JustificativaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atraso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atraso_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Atraso_Justificativa_JustificativaId",
                        column: x => x.JustificativaId,
                        principalTable: "Justificativa",
                        principalColumn: "Id");
                });
            migrationBuilder.CreateTable(
                            name: "Falta",
                            columns: table => new
                            {
                                Id = table.Column<int>(type: "int", nullable: false)
                                    .Annotation("SqlServer:Identity", "1, 1"),
                                AlunoId = table.Column<int>(type: "int", nullable: false),
                                Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                                JustificativaId = table.Column<int>(type: "int", nullable: true)
                            },
                            constraints: table =>
                            {
                                table.PrimaryKey("PK_Falta", x => x.Id);
                                table.ForeignKey(
                                    name: "FK_Falta_Alunos_AlunoId",
                                    column: x => x.AlunoId,
                                    principalTable: "Alunos",
                                    principalColumn: "Id",
                                    onDelete: ReferentialAction.Cascade);
                                table.ForeignKey(
                                    name: "FK_Falta_Justificativa_JustificativaId",
                                    column: x => x.JustificativaId,
                                    principalTable: "Justificativa",
                                    principalColumn: "Id");
                            });
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Turmas_TurmaId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Atraso_Alunos_AlunoId",
                table: "Atraso");

            migrationBuilder.DropForeignKey(
                name: "FK_Entregas_Alunos_AlunoId",
                table: "Entregas");

            migrationBuilder.DropForeignKey(
                name: "FK_Entregas_Avaliacao_AvaliacaoId",
                table: "Entregas");

            migrationBuilder.DropForeignKey(
                name: "FK_Entregas_Tarefa_TarefaId",
                table: "Entregas");

            migrationBuilder.DropForeignKey(
                name: "FK_Falta_Alunos_AlunoId",
                table: "Falta");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefa_Turmas_TurmaId",
                table: "Tarefa");

            migrationBuilder.DropForeignKey(
                name: "FK_Turmas_Professor_ProfessorId",
                table: "Turmas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Turmas",
                table: "Turmas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Entregas",
                table: "Entregas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alunos",
                table: "Alunos");

            migrationBuilder.RenameTable(
                name: "Turmas",
                newName: "Turma");

            migrationBuilder.RenameTable(
                name: "Entregas",
                newName: "Entrega");

            migrationBuilder.RenameTable(
                name: "Alunos",
                newName: "Aluno");

            migrationBuilder.RenameIndex(
                name: "IX_Turmas_ProfessorId",
                table: "Turma",
                newName: "IX_Turma_ProfessorId");

            migrationBuilder.RenameIndex(
                name: "IX_Entregas_TarefaId",
                table: "Entrega",
                newName: "IX_Entrega_TarefaId");

            migrationBuilder.RenameIndex(
                name: "IX_Entregas_AvaliacaoId",
                table: "Entrega",
                newName: "IX_Entrega_AvaliacaoId");

            migrationBuilder.RenameIndex(
                name: "IX_Entregas_AlunoId",
                table: "Entrega",
                newName: "IX_Entrega_AlunoId");

            migrationBuilder.RenameIndex(
                name: "IX_Alunos_TurmaId",
                table: "Aluno",
                newName: "IX_Aluno_TurmaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Turma",
                table: "Turma",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entrega",
                table: "Entrega",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aluno",
                table: "Aluno",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Aluno_Turma_TurmaId",
                table: "Aluno",
                column: "TurmaId",
                principalTable: "Turma",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Atraso_Aluno_AlunoId",
                table: "Atraso",
                column: "AlunoId",
                principalTable: "Aluno",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Entrega_Aluno_AlunoId",
                table: "Entrega",
                column: "AlunoId",
                principalTable: "Aluno",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Entrega_Avaliacao_AvaliacaoId",
                table: "Entrega",
                column: "AvaliacaoId",
                principalTable: "Avaliacao",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrega_Tarefa_TarefaId",
                table: "Entrega",
                column: "TarefaId",
                principalTable: "Tarefa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Falta_Aluno_AlunoId",
                table: "Falta",
                column: "AlunoId",
                principalTable: "Aluno",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefa_Turma_TurmaId",
                table: "Tarefa",
                column: "TurmaId",
                principalTable: "Turma",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Turma_Professor_ProfessorId",
                table: "Turma",
                column: "ProfessorId",
                principalTable: "Professor",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aluno_Turma_TurmaId",
                table: "Aluno");

            migrationBuilder.DropForeignKey(
                name: "FK_Atraso_Aluno_AlunoId",
                table: "Atraso");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrega_Aluno_AlunoId",
                table: "Entrega");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrega_Avaliacao_AvaliacaoId",
                table: "Entrega");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrega_Tarefa_TarefaId",
                table: "Entrega");

            migrationBuilder.DropForeignKey(
                name: "FK_Falta_Aluno_AlunoId",
                table: "Falta");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefa_Turma_TurmaId",
                table: "Tarefa");

            migrationBuilder.DropForeignKey(
                name: "FK_Turma_Professor_ProfessorId",
                table: "Turma");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Turma",
                table: "Turma");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Entrega",
                table: "Entrega");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aluno",
                table: "Aluno");

            migrationBuilder.RenameTable(
                name: "Turma",
                newName: "Turmas");

            migrationBuilder.RenameTable(
                name: "Entrega",
                newName: "Entregas");

            migrationBuilder.RenameTable(
                name: "Aluno",
                newName: "Alunos");

            migrationBuilder.RenameIndex(
                name: "IX_Turma_ProfessorId",
                table: "Turmas",
                newName: "IX_Turmas_ProfessorId");

            migrationBuilder.RenameIndex(
                name: "IX_Entrega_TarefaId",
                table: "Entregas",
                newName: "IX_Entregas_TarefaId");

            migrationBuilder.RenameIndex(
                name: "IX_Entrega_AvaliacaoId",
                table: "Entregas",
                newName: "IX_Entregas_AvaliacaoId");

            migrationBuilder.RenameIndex(
                name: "IX_Entrega_AlunoId",
                table: "Entregas",
                newName: "IX_Entregas_AlunoId");

            migrationBuilder.RenameIndex(
                name: "IX_Aluno_TurmaId",
                table: "Alunos",
                newName: "IX_Alunos_TurmaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Turmas",
                table: "Turmas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entregas",
                table: "Entregas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alunos",
                table: "Alunos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Turmas_TurmaId",
                table: "Alunos",
                column: "TurmaId",
                principalTable: "Turmas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Atraso_Alunos_AlunoId",
                table: "Atraso",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Entregas_Alunos_AlunoId",
                table: "Entregas",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Entregas_Avaliacao_AvaliacaoId",
                table: "Entregas",
                column: "AvaliacaoId",
                principalTable: "Avaliacao",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Entregas_Tarefa_TarefaId",
                table: "Entregas",
                column: "TarefaId",
                principalTable: "Tarefa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Falta_Alunos_AlunoId",
                table: "Falta",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefa_Turmas_TurmaId",
                table: "Tarefa",
                column: "TurmaId",
                principalTable: "Turmas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Turmas_Professor_ProfessorId",
                table: "Turmas",
                column: "ProfessorId",
                principalTable: "Professor",
                principalColumn: "Id");
        }
    }
}
