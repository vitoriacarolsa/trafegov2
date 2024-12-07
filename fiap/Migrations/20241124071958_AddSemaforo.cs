using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fiap.Migrations
{
    /// <inheritdoc />
    public partial class AddSemaforo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_semaforo",
                columns: table => new
                {
                    SemaforoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    localizacao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    estadoAtual = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    tempoVerde = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    tempoVermelho = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    condicoesClimaticas = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ultimaAtualizacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_semaforo", x => x.SemaforoId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_semaforo");
        }
    }
}
