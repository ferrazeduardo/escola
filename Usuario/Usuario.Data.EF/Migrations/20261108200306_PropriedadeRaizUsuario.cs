using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Usuario.Data.EF.Migrations
{
    /// <inheritdoc />
    public partial class PropriedadeRaizUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ST_RAIZ",
                table: "Usuario",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ST_RAIZ",
                table: "Usuario");
        }
    }
}
