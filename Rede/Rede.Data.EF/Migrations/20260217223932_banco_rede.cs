using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Rede.Data.EF.Migrations
{
    /// <inheritdoc />
    public partial class banco_rede : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rede",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RZ_SOCIAL = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    NR_CNPJ = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    DH_REGISTRO = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    US_REGISTRO = table.Column<int>(type: "integer", nullable: false),
                    ST_REDE = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rede", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiaVencimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Dia = table.Column<int>(type: "integer", nullable: false),
                    RedeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaVencimento", x => x.Id);
                    table.ForeignKey(
                        name: "ID_REDE",
                        column: x => x.RedeId,
                        principalTable: "Rede",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Unidade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DS_ENDERECO = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    NR_CEP = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    ST_UNIDADE = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false),
                    DH_REGISTRO = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NR_UNIDADE = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    US_REGISTRO = table.Column<int>(type: "integer", nullable: false),
                    DS_COMPLMENTO = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    RedeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidade", x => x.Id);
                    table.ForeignKey(
                        name: "ID_REDE",
                        column: x => x.RedeId,
                        principalTable: "Rede",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Telefone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NR_TELEFONE = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    UnidadeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefone", x => x.Id);
                    table.ForeignKey(
                        name: "ID_UNIDADE",
                        column: x => x.UnidadeId,
                        principalTable: "Unidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiaVencimento_RedeId",
                table: "DiaVencimento",
                column: "RedeId");

            migrationBuilder.CreateIndex(
                name: "IX_Telefone_UnidadeId",
                table: "Telefone",
                column: "UnidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Unidade_RedeId",
                table: "Unidade",
                column: "RedeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiaVencimento");

            migrationBuilder.DropTable(
                name: "Telefone");

            migrationBuilder.DropTable(
                name: "Unidade");

            migrationBuilder.DropTable(
                name: "Rede");
        }
    }
}
