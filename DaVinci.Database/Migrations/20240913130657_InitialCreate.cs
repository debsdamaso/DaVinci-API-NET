using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DaVinci.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_DV_FEEDBACK");

            migrationBuilder.DropTable(
                name: "TB_DV_PRODUTO");

            migrationBuilder.DropTable(
                name: "TB_DV_CLIENTE");

            migrationBuilder.CreateTable(
                name: "TB_DV_CLIENTE",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_DV_CLIENTE", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "TB_DV_PRODUTO",
                columns: table => new
                {
                    IdProduto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Modelo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_DV_PRODUTO", x => x.IdProduto);
                    table.ForeignKey(
                        name: "FK_TB_DV_PRODUTO_TB_DV_CLIENTE_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "TB_DV_CLIENTE",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_DV_FEEDBACK",
                columns: table => new
                {
                    IdFeedback = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comentario = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    DataFeedback = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Avaliacao = table.Column<int>(type: "int", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    IdProduto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_DV_FEEDBACK", x => x.IdFeedback);
                    table.ForeignKey(
                        name: "FK_TB_DV_FEEDBACK_TB_DV_CLIENTE_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "TB_DV_CLIENTE",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_DV_FEEDBACK_TB_DV_PRODUTO_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "TB_DV_PRODUTO",
                        principalColumn: "IdProduto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_DV_FEEDBACK_IdCliente",
                table: "TB_DV_FEEDBACK",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_TB_DV_FEEDBACK_IdProduto",
                table: "TB_DV_FEEDBACK",
                column: "IdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_TB_DV_PRODUTO_IdCliente",
                table: "TB_DV_PRODUTO",
                column: "IdCliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_DV_FEEDBACK");

            migrationBuilder.DropTable(
                name: "TB_DV_PRODUTO");

            migrationBuilder.DropTable(
                name: "TB_DV_CLIENTE");
        }
    }
}
