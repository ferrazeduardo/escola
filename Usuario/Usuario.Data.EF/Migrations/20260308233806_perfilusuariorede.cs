using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Usuario.Data.EF.Migrations
{
    /// <inheritdoc />
    public partial class perfilusuariorede : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PerfilUnidadeUsuario");

            migrationBuilder.DropTable(
                name: "PerfilUnidade");

            migrationBuilder.DropTable(
                name: "Unidade");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioRede",
                table: "UsuarioRede");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UsuarioRede",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioRede",
                table: "UsuarioRede",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PerfilUsuarioRede",
                columns: table => new
                {
                    ID_PERFIL = table.Column<int>(type: "integer", nullable: false),
                    ID_USUARIO_REDE = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfilUsuarioRede", x => new { x.ID_PERFIL, x.ID_USUARIO_REDE });
                    table.ForeignKey(
                        name: "FK_PerfilUsuarioRede_Perfil_ID_PERFIL",
                        column: x => x.ID_PERFIL,
                        principalTable: "Perfil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PerfilUsuarioRede_UsuarioRede_ID_USUARIO_REDE",
                        column: x => x.ID_USUARIO_REDE,
                        principalTable: "UsuarioRede",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRede_ID_REDE",
                table: "UsuarioRede",
                column: "ID_REDE");

            migrationBuilder.CreateIndex(
                name: "IX_PerfilUsuarioRede_ID_USUARIO_REDE",
                table: "PerfilUsuarioRede",
                column: "ID_USUARIO_REDE");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PerfilUsuarioRede");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioRede",
                table: "UsuarioRede");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioRede_ID_REDE",
                table: "UsuarioRede");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UsuarioRede");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioRede",
                table: "UsuarioRede",
                columns: new[] { "ID_REDE", "ID_USUARIO" });

            migrationBuilder.CreateTable(
                name: "Unidade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    ID_REDE = table.Column<int>(type: "integer", nullable: false),
                    DS_UNIDADE = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_REDE_UNIDADE",
                        column: x => x.ID_REDE,
                        principalTable: "Rede",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PerfilUnidade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ID_PERFIL = table.Column<int>(type: "integer", nullable: false),
                    ID_UNIDADE = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfilUnidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PerfilUnidade_Perfil_ID_PERFIL",
                        column: x => x.ID_PERFIL,
                        principalTable: "Perfil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PerfilUnidade_Unidade_ID_UNIDADE",
                        column: x => x.ID_UNIDADE,
                        principalTable: "Unidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PerfilUnidadeUsuario",
                columns: table => new
                {
                    ID_PERFIL_UNIDADE = table.Column<int>(type: "integer", nullable: false),
                    ID_USUARIO = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfilUnidadeUsuario", x => new { x.ID_PERFIL_UNIDADE, x.ID_USUARIO });
                    table.ForeignKey(
                        name: "FK_PerfilUnidadeUsuario_PerfilUnidade_ID_PERFIL_UNIDADE",
                        column: x => x.ID_PERFIL_UNIDADE,
                        principalTable: "PerfilUnidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PerfilUnidadeUsuario_Usuario_ID_USUARIO",
                        column: x => x.ID_USUARIO,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PerfilUnidade_ID_PERFIL",
                table: "PerfilUnidade",
                column: "ID_PERFIL");

            migrationBuilder.CreateIndex(
                name: "IX_PerfilUnidade_ID_UNIDADE",
                table: "PerfilUnidade",
                column: "ID_UNIDADE");

            migrationBuilder.CreateIndex(
                name: "IX_PerfilUnidadeUsuario_ID_USUARIO",
                table: "PerfilUnidadeUsuario",
                column: "ID_USUARIO");

            migrationBuilder.CreateIndex(
                name: "IX_Unidade_ID_REDE",
                table: "Unidade",
                column: "ID_REDE");
        }
    }
}
