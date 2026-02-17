using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Usuario.Data.EF.Migrations
{
    /// <inheritdoc />
    public partial class remover_tabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "perfis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DS_PERFIL = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perfis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unidade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DS_UNIDADE = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NM_USUARIO = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DT_NASCIMENTO = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NR_CPF = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    SEG_SENHA = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    SALT = table.Column<byte[]>(type: "bytea", maxLength: 100, nullable: false),
                    DS_EMAIL = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "perfilUnidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ID_UNIDADE = table.Column<int>(type: "integer", nullable: false),
                    ID_PERFIL = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perfilUnidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_perfilUnidades_Unidade_ID_UNIDADE",
                        column: x => x.ID_UNIDADE,
                        principalTable: "Unidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_perfilUnidades_perfis_ID_PERFIL",
                        column: x => x.ID_PERFIL,
                        principalTable: "perfis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "perfilUnidadeUsuarios",
                columns: table => new
                {
                    ID_PERFIL_UNIDADE = table.Column<int>(type: "integer", nullable: false),
                    ID_USUARIO = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perfilUnidadeUsuarios", x => new { x.ID_PERFIL_UNIDADE, x.ID_USUARIO });
                    table.ForeignKey(
                        name: "FK_perfilUnidadeUsuarios_perfilUnidades_ID_PERFIL_UNIDADE",
                        column: x => x.ID_PERFIL_UNIDADE,
                        principalTable: "perfilUnidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_perfilUnidadeUsuarios_usuarios_ID_USUARIO",
                        column: x => x.ID_USUARIO,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_perfilUnidades_ID_PERFIL",
                table: "perfilUnidades",
                column: "ID_PERFIL");

            migrationBuilder.CreateIndex(
                name: "IX_perfilUnidades_ID_UNIDADE",
                table: "perfilUnidades",
                column: "ID_UNIDADE");

            migrationBuilder.CreateIndex(
                name: "IX_perfilUnidadeUsuarios_ID_USUARIO",
                table: "perfilUnidadeUsuarios",
                column: "ID_USUARIO");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_DS_EMAIL",
                table: "usuarios",
                column: "DS_EMAIL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_NR_CPF",
                table: "usuarios",
                column: "NR_CPF",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "perfilUnidadeUsuarios");

            migrationBuilder.DropTable(
                name: "perfilUnidades");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "Unidade");

            migrationBuilder.DropTable(
                name: "perfis");
        }
    }
}
