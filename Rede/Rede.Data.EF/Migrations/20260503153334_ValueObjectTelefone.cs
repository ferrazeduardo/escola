using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rede.Data.EF.Migrations
{
    /// <inheritdoc />
    public partial class ValueObjectTelefone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UNIDADE_TELEFONE",
                table: "Telefone");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Telefone",
                table: "Telefone");

            migrationBuilder.RenameTable(
                name: "Telefone",
                newName: "UnidadeTelefones");

            migrationBuilder.RenameColumn(
                name: "NR_TELEFONE",
                table: "UnidadeTelefones",
                newName: "Numero");

            migrationBuilder.RenameIndex(
                name: "IX_Telefone_ID_UNIDADE",
                table: "UnidadeTelefones",
                newName: "IX_UnidadeTelefones_ID_UNIDADE");

            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "UnidadeTelefones",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(60)",
                oldMaxLength: 60);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnidadeTelefones",
                table: "UnidadeTelefones",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UnidadeTelefones_Unidade_ID_UNIDADE",
                table: "UnidadeTelefones",
                column: "ID_UNIDADE",
                principalTable: "Unidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UnidadeTelefones_Unidade_ID_UNIDADE",
                table: "UnidadeTelefones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnidadeTelefones",
                table: "UnidadeTelefones");

            migrationBuilder.RenameTable(
                name: "UnidadeTelefones",
                newName: "Telefone");

            migrationBuilder.RenameColumn(
                name: "Numero",
                table: "Telefone",
                newName: "NR_TELEFONE");

            migrationBuilder.RenameIndex(
                name: "IX_UnidadeTelefones_ID_UNIDADE",
                table: "Telefone",
                newName: "IX_Telefone_ID_UNIDADE");

            migrationBuilder.AlterColumn<string>(
                name: "NR_TELEFONE",
                table: "Telefone",
                type: "character varying(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Telefone",
                table: "Telefone",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UNIDADE_TELEFONE",
                table: "Telefone",
                column: "ID_UNIDADE",
                principalTable: "Unidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
