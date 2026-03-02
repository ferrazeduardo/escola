using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Usuario.Data.EF.Migrations
{
    /// <inheritdoc />
    public partial class usuarioRedes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsuarioRede",
                columns: table => new
                {
                    ID_USUARIO = table.Column<int>(type: "integer", nullable: false),
                    ID_REDE = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioRede", x => new { x.ID_REDE, x.ID_USUARIO });
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
                name: "IX_UsuarioRede_ID_USUARIO",
                table: "UsuarioRede",
                column: "ID_USUARIO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioRede");
        }
    }
}
