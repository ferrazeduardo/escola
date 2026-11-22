using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Usuario.Data.EF.Migrations
{
    /// <inheritdoc />
    public partial class SeedPermissoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Permisao",
                table: "Permisao");

            migrationBuilder.RenameTable(
                name: "Permisao",
                newName: "Permissao");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permissao",
                table: "Permissao",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Perfil",
                columns: new[] { "Id", "DS_PERFIL" },
                values: new object[] { 1, "Administrador" });

            migrationBuilder.InsertData(
                table: "PerfilPermissao",
                columns: new[] { "ID_PERFIL", "ID_PERMISSAO" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 1, 6 },
                    { 1, 7 },
                    { 1, 8 },
                    { 1, 9 },
                    { 1, 10 },
                    { 1, 11 },
                    { 1, 12 }
                });

            migrationBuilder.InsertData(
                table: "Permissao",
                columns: new[] { "Id", "DS_MODULO", "DS_PERMISSAO", "PL_PERMISSAO" },
                values: new object[,]
                {
                    { 1, "Acadêmico", "Visualizar alunos", "aluno.listar" },
                    { 2, "Acadêmico", "Cadastrar aluno", "aluno.criar" },
                    { 3, "Acadêmico", "Gerenciar turmas", "turma.gerenciar" },
                    { 4, "Acadêmico", "Lançar notas", "nota.lancar" },
                    { 5, "Acadêmico", "Lançar frequência", "frequencia.lancar" },
                    { 6, "Acadêmico", "Transferir aluno de turma", "aluno.transferir" },
                    { 7, "Rede", "Gerenciar dados da rede", "rede.gerenciar" },
                    { 8, "Rede", "Gerenciar unidades escolares", "unidade.gerenciar" },
                    { 9, "Rede", "Gerenciar séries", "serie.gerenciar" },
                    { 10, "Sistema", "Gerenciar usuários", "usuario.gerenciar" },
                    { 11, "Sistema", "Gerenciar perfis", "perfil.gerenciar" },
                    { 12, "Acadêmico", "Matricular aluno em turma", "aluno.matricular" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permissao_PL_PERMISSAO",
                table: "Permissao",
                column: "PL_PERMISSAO",
                unique: true);

            // O seed grava os Ids à mão e o PostgreSQL não avança a sequence da coluna identity.
            // Sem isso, o próximo perfil cadastrado pela aplicação tentaria usar o Id 1 (chave duplicada).
            migrationBuilder.Sql(@"SELECT setval(pg_get_serial_sequence('""Perfil""', 'Id'), (SELECT MAX(""Id"") FROM ""Perfil""));");
            migrationBuilder.Sql(@"SELECT setval(pg_get_serial_sequence('""Permissao""', 'Id'), (SELECT MAX(""Id"") FROM ""Permissao""));");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Permissao",
                table: "Permissao");

            migrationBuilder.DropIndex(
                name: "IX_Permissao_PL_PERMISSAO",
                table: "Permissao");

            migrationBuilder.DeleteData(
                table: "Perfil",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PerfilPermissao",
                keyColumns: new[] { "ID_PERFIL", "ID_PERMISSAO" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "PerfilPermissao",
                keyColumns: new[] { "ID_PERFIL", "ID_PERMISSAO" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "PerfilPermissao",
                keyColumns: new[] { "ID_PERFIL", "ID_PERMISSAO" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "PerfilPermissao",
                keyColumns: new[] { "ID_PERFIL", "ID_PERMISSAO" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "PerfilPermissao",
                keyColumns: new[] { "ID_PERFIL", "ID_PERMISSAO" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "PerfilPermissao",
                keyColumns: new[] { "ID_PERFIL", "ID_PERMISSAO" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "PerfilPermissao",
                keyColumns: new[] { "ID_PERFIL", "ID_PERMISSAO" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "PerfilPermissao",
                keyColumns: new[] { "ID_PERFIL", "ID_PERMISSAO" },
                keyValues: new object[] { 1, 8 });

            migrationBuilder.DeleteData(
                table: "PerfilPermissao",
                keyColumns: new[] { "ID_PERFIL", "ID_PERMISSAO" },
                keyValues: new object[] { 1, 9 });

            migrationBuilder.DeleteData(
                table: "PerfilPermissao",
                keyColumns: new[] { "ID_PERFIL", "ID_PERMISSAO" },
                keyValues: new object[] { 1, 10 });

            migrationBuilder.DeleteData(
                table: "PerfilPermissao",
                keyColumns: new[] { "ID_PERFIL", "ID_PERMISSAO" },
                keyValues: new object[] { 1, 11 });

            migrationBuilder.DeleteData(
                table: "PerfilPermissao",
                keyColumns: new[] { "ID_PERFIL", "ID_PERMISSAO" },
                keyValues: new object[] { 1, 12 });

            migrationBuilder.DeleteData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.RenameTable(
                name: "Permissao",
                newName: "Permisao");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permisao",
                table: "Permisao",
                column: "Id");
        }
    }
}
