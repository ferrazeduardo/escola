using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Rede.Data.EF.Migrations
{
    /// <inheritdoc />
    public partial class ValueObjectSala : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Numero",
                table: "UnidadeTelefones",
                newName: "NR_TELEFONE");

            migrationBuilder.CreateTable(
                name: "UnidadeSala",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NR_SALA = table.Column<string>(type: "text", nullable: false),
                    QT_MAXIMA = table.Column<int>(type: "integer", nullable: false),
                    ID_UNIDADE = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadeSala", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnidadeSala_Unidade_ID_UNIDADE",
                        column: x => x.ID_UNIDADE,
                        principalTable: "Unidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UnidadeSala_ID_UNIDADE",
                table: "UnidadeSala",
                column: "ID_UNIDADE");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UnidadeSala");

            migrationBuilder.RenameColumn(
                name: "NR_TELEFONE",
                table: "UnidadeTelefones",
                newName: "Numero");
        }
    }
}
