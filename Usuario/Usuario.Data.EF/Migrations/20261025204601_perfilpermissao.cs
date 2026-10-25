using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Usuario.Data.EF.Migrations
{
    /// <inheritdoc />
    public partial class perfilpermissao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PerfilUsuarioRede_Perfil_ID_PERFIL",
                table: "PerfilUsuarioRede");

            migrationBuilder.DropForeignKey(
                name: "FK_PerfilUsuarioRede_UsuarioRede_ID_USUARIO_REDE",
                table: "PerfilUsuarioRede");

            migrationBuilder.DropTable(
                name: "UsuarioRede");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PerfilUsuarioRede",
                table: "PerfilUsuarioRede");

            migrationBuilder.RenameTable(
                name: "PerfilUsuarioRede",
                newName: "perfilUsuarioRedes");

            migrationBuilder.RenameColumn(
                name: "ID_USUARIO_REDE",
                table: "perfilUsuarioRedes",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_PerfilUsuarioRede_ID_USUARIO_REDE",
                table: "perfilUsuarioRedes",
                newName: "IX_perfilUsuarioRedes_UsuarioId");

            migrationBuilder.AlterColumn<string>(
                name: "DS_REDE",
                table: "Rede",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Rede",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "ID_REDE",
                table: "perfilUsuarioRedes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ID_USUARIO",
                table: "perfilUsuarioRedes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PerfilId",
                table: "perfilUsuarioRedes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RedeId",
                table: "perfilUsuarioRedes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_perfilUsuarioRedes",
                table: "perfilUsuarioRedes",
                columns: new[] { "ID_PERFIL", "ID_REDE", "ID_USUARIO" });

            migrationBuilder.CreateTable(
                name: "PerfilPermissao",
                columns: table => new
                {
                    ID_PERFIL = table.Column<int>(type: "integer", nullable: false),
                    ID_PERMISSAO = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfilPermissao", x => new { x.ID_PERFIL, x.ID_PERMISSAO });
                });

            migrationBuilder.CreateTable(
                name: "Permisao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PL_PERMISSAO = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    DS_PERMISSAO = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DS_MODULO = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permisao", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_perfilUsuarioRedes_PerfilId",
                table: "perfilUsuarioRedes",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_perfilUsuarioRedes_RedeId",
                table: "perfilUsuarioRedes",
                column: "RedeId");

            migrationBuilder.AddForeignKey(
                name: "FK_perfilUsuarioRedes_Perfil_PerfilId",
                table: "perfilUsuarioRedes",
                column: "PerfilId",
                principalTable: "Perfil",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_perfilUsuarioRedes_Rede_RedeId",
                table: "perfilUsuarioRedes",
                column: "RedeId",
                principalTable: "Rede",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_perfilUsuarioRedes_Usuario_UsuarioId",
                table: "perfilUsuarioRedes",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_perfilUsuarioRedes_Perfil_PerfilId",
                table: "perfilUsuarioRedes");

            migrationBuilder.DropForeignKey(
                name: "FK_perfilUsuarioRedes_Rede_RedeId",
                table: "perfilUsuarioRedes");

            migrationBuilder.DropForeignKey(
                name: "FK_perfilUsuarioRedes_Usuario_UsuarioId",
                table: "perfilUsuarioRedes");

            migrationBuilder.DropTable(
                name: "PerfilPermissao");

            migrationBuilder.DropTable(
                name: "Permisao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_perfilUsuarioRedes",
                table: "perfilUsuarioRedes");

            migrationBuilder.DropIndex(
                name: "IX_perfilUsuarioRedes_PerfilId",
                table: "perfilUsuarioRedes");

            migrationBuilder.DropIndex(
                name: "IX_perfilUsuarioRedes_RedeId",
                table: "perfilUsuarioRedes");

            migrationBuilder.DropColumn(
                name: "ID_REDE",
                table: "perfilUsuarioRedes");

            migrationBuilder.DropColumn(
                name: "ID_USUARIO",
                table: "perfilUsuarioRedes");

            migrationBuilder.DropColumn(
                name: "PerfilId",
                table: "perfilUsuarioRedes");

            migrationBuilder.DropColumn(
                name: "RedeId",
                table: "perfilUsuarioRedes");

            migrationBuilder.RenameTable(
                name: "perfilUsuarioRedes",
                newName: "PerfilUsuarioRede");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "PerfilUsuarioRede",
                newName: "ID_USUARIO_REDE");

            migrationBuilder.RenameIndex(
                name: "IX_perfilUsuarioRedes_UsuarioId",
                table: "PerfilUsuarioRede",
                newName: "IX_PerfilUsuarioRede_ID_USUARIO_REDE");

            migrationBuilder.AlterColumn<string>(
                name: "DS_REDE",
                table: "Rede",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Rede",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PerfilUsuarioRede",
                table: "PerfilUsuarioRede",
                columns: new[] { "ID_PERFIL", "ID_USUARIO_REDE" });

            migrationBuilder.CreateTable(
                name: "UsuarioRede",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ID_REDE = table.Column<int>(type: "integer", nullable: false),
                    ID_USUARIO = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioRede", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioRede_Rede_ID_REDE",
                        column: x => x.ID_REDE,
                        principalTable: "Rede",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioRede_Usuario_ID_USUARIO",
                        column: x => x.ID_USUARIO,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRede_ID_REDE",
                table: "UsuarioRede",
                column: "ID_REDE");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRede_ID_USUARIO",
                table: "UsuarioRede",
                column: "ID_USUARIO");

            migrationBuilder.AddForeignKey(
                name: "FK_PerfilUsuarioRede_Perfil_ID_PERFIL",
                table: "PerfilUsuarioRede",
                column: "ID_PERFIL",
                principalTable: "Perfil",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PerfilUsuarioRede_UsuarioRede_ID_USUARIO_REDE",
                table: "PerfilUsuarioRede",
                column: "ID_USUARIO_REDE",
                principalTable: "UsuarioRede",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
