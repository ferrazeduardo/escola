using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rede.Data.EF.Migrations
{
    /// <inheritdoc />
    public partial class chave_estrangeira_nas_tabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "ID_REDE",
                table: "DiaVencimento");

            migrationBuilder.DropForeignKey(
                name: "ID_UNIDADE",
                table: "Telefone");

            migrationBuilder.DropForeignKey(
                name: "ID_REDE",
                table: "Unidade");

            migrationBuilder.RenameColumn(
                name: "RedeId",
                table: "Unidade",
                newName: "ID_REDE");

            migrationBuilder.RenameIndex(
                name: "IX_Unidade_RedeId",
                table: "Unidade",
                newName: "IX_Unidade_ID_REDE");

            migrationBuilder.RenameColumn(
                name: "UnidadeId",
                table: "Telefone",
                newName: "ID_UNIDADE");

            migrationBuilder.RenameIndex(
                name: "IX_Telefone_UnidadeId",
                table: "Telefone",
                newName: "IX_Telefone_ID_UNIDADE");

            migrationBuilder.RenameColumn(
                name: "RedeId",
                table: "DiaVencimento",
                newName: "ID_REDE");

            migrationBuilder.RenameIndex(
                name: "IX_DiaVencimento_RedeId",
                table: "DiaVencimento",
                newName: "IX_DiaVencimento_ID_REDE");

            migrationBuilder.AddForeignKey(
                name: "FK_REDE_DIAVENCIMENTO",
                table: "DiaVencimento",
                column: "ID_REDE",
                principalTable: "Rede",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UNIDADE_TELEFONE",
                table: "Telefone",
                column: "ID_UNIDADE",
                principalTable: "Unidade",
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
                name: "FK_REDE_DIAVENCIMENTO",
                table: "DiaVencimento");

            migrationBuilder.DropForeignKey(
                name: "FK_UNIDADE_TELEFONE",
                table: "Telefone");

            migrationBuilder.DropForeignKey(
                name: "FK_REDE_UNIDADE",
                table: "Unidade");

            migrationBuilder.RenameColumn(
                name: "ID_REDE",
                table: "Unidade",
                newName: "RedeId");

            migrationBuilder.RenameIndex(
                name: "IX_Unidade_ID_REDE",
                table: "Unidade",
                newName: "IX_Unidade_RedeId");

            migrationBuilder.RenameColumn(
                name: "ID_UNIDADE",
                table: "Telefone",
                newName: "UnidadeId");

            migrationBuilder.RenameIndex(
                name: "IX_Telefone_ID_UNIDADE",
                table: "Telefone",
                newName: "IX_Telefone_UnidadeId");

            migrationBuilder.RenameColumn(
                name: "ID_REDE",
                table: "DiaVencimento",
                newName: "RedeId");

            migrationBuilder.RenameIndex(
                name: "IX_DiaVencimento_ID_REDE",
                table: "DiaVencimento",
                newName: "IX_DiaVencimento_RedeId");

            migrationBuilder.AddForeignKey(
                name: "ID_REDE",
                table: "DiaVencimento",
                column: "RedeId",
                principalTable: "Rede",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "ID_UNIDADE",
                table: "Telefone",
                column: "UnidadeId",
                principalTable: "Unidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "ID_REDE",
                table: "Unidade",
                column: "RedeId",
                principalTable: "Rede",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
