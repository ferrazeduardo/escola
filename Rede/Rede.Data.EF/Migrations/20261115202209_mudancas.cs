using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rede.Data.EF.Migrations
{
    /// <inheritdoc />
    public partial class mudancas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RedeUnidade",
                columns: table => new
                {
                    id_rede = table.Column<int>(type: "integer", nullable: false),
                    id_unidade = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RedeUnidade", x => new { x.id_rede, x.id_unidade });
                });

            // preserva os vínculos existentes antes de remover a coluna ID_REDE
            migrationBuilder.Sql(
                "INSERT INTO \"RedeUnidade\" (id_rede, id_unidade) SELECT \"ID_REDE\", \"Id\" FROM \"Unidade\" WHERE \"ID_REDE\" IS NOT NULL;");

            migrationBuilder.DropForeignKey(
                name: "FK_REDE_UNIDADE",
                table: "Unidade");

            migrationBuilder.DropIndex(
                name: "IX_Unidade_ID_REDE",
                table: "Unidade");

            migrationBuilder.DropColumn(
                name: "ID_REDE",
                table: "Unidade");

            migrationBuilder.DropColumn(
                name: "US_REGISTRO",
                table: "Rede");

            // 'S' -> true, qualquer outro valor ('N') -> false
            migrationBuilder.Sql(
                "ALTER TABLE \"Unidade\" ALTER COLUMN \"ST_UNIDADE\" TYPE boolean USING (\"ST_UNIDADE\" = 'S');");

            migrationBuilder.Sql(
                "ALTER TABLE \"Rede\" ALTER COLUMN \"ST_REDE\" TYPE boolean USING (\"ST_REDE\" = 'S');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "ALTER TABLE \"Unidade\" ALTER COLUMN \"ST_UNIDADE\" TYPE character varying(1) USING (CASE WHEN \"ST_UNIDADE\" THEN 'S' ELSE 'N' END);");

            migrationBuilder.AddColumn<int>(
                name: "ID_REDE",
                table: "Unidade",
                type: "integer",
                nullable: true);

            migrationBuilder.Sql(
                "ALTER TABLE \"Rede\" ALTER COLUMN \"ST_REDE\" TYPE character varying(1) USING (CASE WHEN \"ST_REDE\" THEN 'S' ELSE 'N' END);");

            migrationBuilder.AddColumn<int>(
                name: "US_REGISTRO",
                table: "Rede",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Unidade_ID_REDE",
                table: "Unidade",
                column: "ID_REDE");

            migrationBuilder.AddForeignKey(
                name: "FK_REDE_UNIDADE",
                table: "Unidade",
                column: "ID_REDE",
                principalTable: "Rede",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.Sql(
                "UPDATE \"Unidade\" u SET \"ID_REDE\" = ru.id_rede FROM (SELECT id_unidade, MIN(id_rede) AS id_rede FROM \"RedeUnidade\" GROUP BY id_unidade) ru WHERE ru.id_unidade = u.\"Id\";");

            migrationBuilder.DropTable(
                name: "RedeUnidade");
        }
    }
}
