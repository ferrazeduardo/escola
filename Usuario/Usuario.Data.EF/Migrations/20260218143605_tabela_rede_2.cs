using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Usuario.Data.EF.Migrations
{
    /// <inheritdoc />
    public partial class tabela_rede_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_perfilUnidades_Unidade_ID_UNIDADE",
                table: "perfilUnidades");

            migrationBuilder.DropForeignKey(
                name: "FK_perfilUnidades_perfis_ID_PERFIL",
                table: "perfilUnidades");

            migrationBuilder.DropForeignKey(
                name: "FK_perfilUnidadeUsuarios_perfilUnidades_ID_PERFIL_UNIDADE",
                table: "perfilUnidadeUsuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_perfilUnidadeUsuarios_usuarios_ID_USUARIO",
                table: "perfilUnidadeUsuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_perfis",
                table: "perfis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_perfilUnidadeUsuarios",
                table: "perfilUnidadeUsuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_perfilUnidades",
                table: "perfilUnidades");

            migrationBuilder.RenameTable(
                name: "usuarios",
                newName: "Usuario");

            migrationBuilder.RenameTable(
                name: "perfis",
                newName: "Perfil");

            migrationBuilder.RenameTable(
                name: "perfilUnidadeUsuarios",
                newName: "PerfilUnidadeUsuario");

            migrationBuilder.RenameTable(
                name: "perfilUnidades",
                newName: "PerfilUnidade");

            migrationBuilder.RenameIndex(
                name: "IX_usuarios_NR_CPF",
                table: "Usuario",
                newName: "IX_Usuario_NR_CPF");

            migrationBuilder.RenameIndex(
                name: "IX_usuarios_DS_EMAIL",
                table: "Usuario",
                newName: "IX_Usuario_DS_EMAIL");

            migrationBuilder.RenameIndex(
                name: "IX_perfilUnidadeUsuarios_ID_USUARIO",
                table: "PerfilUnidadeUsuario",
                newName: "IX_PerfilUnidadeUsuario_ID_USUARIO");

            migrationBuilder.RenameIndex(
                name: "IX_perfilUnidades_ID_UNIDADE",
                table: "PerfilUnidade",
                newName: "IX_PerfilUnidade_ID_UNIDADE");

            migrationBuilder.RenameIndex(
                name: "IX_perfilUnidades_ID_PERFIL",
                table: "PerfilUnidade",
                newName: "IX_PerfilUnidade_ID_PERFIL");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Unidade",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "ID_REDE",
                table: "Unidade",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Perfil",
                table: "Perfil",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PerfilUnidadeUsuario",
                table: "PerfilUnidadeUsuario",
                columns: new[] { "ID_PERFIL_UNIDADE", "ID_USUARIO" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PerfilUnidade",
                table: "PerfilUnidade",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Rede",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    DS_REDE = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rede", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Unidade_ID_REDE",
                table: "Unidade",
                column: "ID_REDE");

            migrationBuilder.AddForeignKey(
                name: "FK_PerfilUnidade_Perfil_ID_PERFIL",
                table: "PerfilUnidade",
                column: "ID_PERFIL",
                principalTable: "Perfil",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PerfilUnidade_Unidade_ID_UNIDADE",
                table: "PerfilUnidade",
                column: "ID_UNIDADE",
                principalTable: "Unidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PerfilUnidadeUsuario_PerfilUnidade_ID_PERFIL_UNIDADE",
                table: "PerfilUnidadeUsuario",
                column: "ID_PERFIL_UNIDADE",
                principalTable: "PerfilUnidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PerfilUnidadeUsuario_Usuario_ID_USUARIO",
                table: "PerfilUnidadeUsuario",
                column: "ID_USUARIO",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_REDE_UNIDADE",
                table: "Unidade",
                column: "ID_REDE",
                principalTable: "Rede",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PerfilUnidade_Perfil_ID_PERFIL",
                table: "PerfilUnidade");

            migrationBuilder.DropForeignKey(
                name: "FK_PerfilUnidade_Unidade_ID_UNIDADE",
                table: "PerfilUnidade");

            migrationBuilder.DropForeignKey(
                name: "FK_PerfilUnidadeUsuario_PerfilUnidade_ID_PERFIL_UNIDADE",
                table: "PerfilUnidadeUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_PerfilUnidadeUsuario_Usuario_ID_USUARIO",
                table: "PerfilUnidadeUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_REDE_UNIDADE",
                table: "Unidade");

            migrationBuilder.DropTable(
                name: "Rede");

            migrationBuilder.DropIndex(
                name: "IX_Unidade_ID_REDE",
                table: "Unidade");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PerfilUnidadeUsuario",
                table: "PerfilUnidadeUsuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PerfilUnidade",
                table: "PerfilUnidade");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Perfil",
                table: "Perfil");

            migrationBuilder.DropColumn(
                name: "ID_REDE",
                table: "Unidade");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "usuarios");

            migrationBuilder.RenameTable(
                name: "PerfilUnidadeUsuario",
                newName: "perfilUnidadeUsuarios");

            migrationBuilder.RenameTable(
                name: "PerfilUnidade",
                newName: "perfilUnidades");

            migrationBuilder.RenameTable(
                name: "Perfil",
                newName: "perfis");

            migrationBuilder.RenameIndex(
                name: "IX_Usuario_NR_CPF",
                table: "usuarios",
                newName: "IX_usuarios_NR_CPF");

            migrationBuilder.RenameIndex(
                name: "IX_Usuario_DS_EMAIL",
                table: "usuarios",
                newName: "IX_usuarios_DS_EMAIL");

            migrationBuilder.RenameIndex(
                name: "IX_PerfilUnidadeUsuario_ID_USUARIO",
                table: "perfilUnidadeUsuarios",
                newName: "IX_perfilUnidadeUsuarios_ID_USUARIO");

            migrationBuilder.RenameIndex(
                name: "IX_PerfilUnidade_ID_UNIDADE",
                table: "perfilUnidades",
                newName: "IX_perfilUnidades_ID_UNIDADE");

            migrationBuilder.RenameIndex(
                name: "IX_PerfilUnidade_ID_PERFIL",
                table: "perfilUnidades",
                newName: "IX_perfilUnidades_ID_PERFIL");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Unidade",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_perfilUnidadeUsuarios",
                table: "perfilUnidadeUsuarios",
                columns: new[] { "ID_PERFIL_UNIDADE", "ID_USUARIO" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_perfilUnidades",
                table: "perfilUnidades",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_perfis",
                table: "perfis",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_perfilUnidades_Unidade_ID_UNIDADE",
                table: "perfilUnidades",
                column: "ID_UNIDADE",
                principalTable: "Unidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_perfilUnidades_perfis_ID_PERFIL",
                table: "perfilUnidades",
                column: "ID_PERFIL",
                principalTable: "perfis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_perfilUnidadeUsuarios_perfilUnidades_ID_PERFIL_UNIDADE",
                table: "perfilUnidadeUsuarios",
                column: "ID_PERFIL_UNIDADE",
                principalTable: "perfilUnidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_perfilUnidadeUsuarios_usuarios_ID_USUARIO",
                table: "perfilUnidadeUsuarios",
                column: "ID_USUARIO",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
