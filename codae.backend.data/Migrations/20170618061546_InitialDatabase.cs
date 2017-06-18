using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace codae.backend.data.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agrupamentos",
                columns: table => new
                {
                    AgrupamentoId = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agrupamentos", x => x.AgrupamentoId);
                });

            migrationBuilder.CreateTable(
                name: "Pratos",
                columns: table => new
                {
                    PratoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GrupoPratoId = table.Column<int>(nullable: true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pratos", x => x.PratoId);
                    table.ForeignKey(
                        name: "FK_Pratos_Pratos_GrupoPratoId",
                        column: x => x.GrupoPratoId,
                        principalTable: "Pratos",
                        principalColumn: "PratoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    ServicoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.ServicoId);
                });

            migrationBuilder.CreateTable(
                name: "TiposGestao",
                columns: table => new
                {
                    TipoGestaoId = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposGestao", x => x.TipoGestaoId);
                });

            migrationBuilder.CreateTable(
                name: "TiposUnidadeEscolar",
                columns: table => new
                {
                    TipoUnidadeEscolarId = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposUnidadeEscolar", x => x.TipoUnidadeEscolarId);
                });

            migrationBuilder.CreateTable(
                name: "Regioes",
                columns: table => new
                {
                    RegiaoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AgrupamentoId = table.Column<int>(nullable: false),
                    Dirigente = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regioes", x => x.RegiaoId);
                    table.ForeignKey(
                        name: "FK_Regioes_Agrupamentos_AgrupamentoId",
                        column: x => x.AgrupamentoId,
                        principalTable: "Agrupamentos",
                        principalColumn: "AgrupamentoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItensServico",
                columns: table => new
                {
                    ServicoId = table.Column<int>(nullable: false),
                    PratoId = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensServico", x => new { x.ServicoId, x.PratoId, x.Nome });
                    table.ForeignKey(
                        name: "FK_ItensServico_Pratos_PratoId",
                        column: x => x.PratoId,
                        principalTable: "Pratos",
                        principalColumn: "PratoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItensServico_Servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servicos",
                        principalColumn: "ServicoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cardapios",
                columns: table => new
                {
                    CardapioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AgrupamentoId = table.Column<int>(nullable: false),
                    DataInicioVigencia = table.Column<DateTime>(nullable: false),
                    DataTerminoVigencia = table.Column<DateTime>(nullable: false),
                    TipoGestaoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cardapios", x => x.CardapioId);
                    table.ForeignKey(
                        name: "FK_Cardapios_Agrupamentos_AgrupamentoId",
                        column: x => x.AgrupamentoId,
                        principalTable: "Agrupamentos",
                        principalColumn: "AgrupamentoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cardapios_TiposGestao_TipoGestaoId",
                        column: x => x.TipoGestaoId,
                        principalTable: "TiposGestao",
                        principalColumn: "TipoGestaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UnidadesEscolares",
                columns: table => new
                {
                    UnidadeEscolarId = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    RegiaoId = table.Column<int>(nullable: false),
                    TipoGestaoId = table.Column<int>(nullable: false),
                    TipoUnidadeEscolarId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadesEscolares", x => x.UnidadeEscolarId);
                    table.ForeignKey(
                        name: "FK_UnidadesEscolares_TiposGestao_TipoGestaoId",
                        column: x => x.TipoGestaoId,
                        principalTable: "TiposGestao",
                        principalColumn: "TipoGestaoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnidadesEscolares_TiposUnidadeEscolar_TipoUnidadeEscolarId",
                        column: x => x.TipoUnidadeEscolarId,
                        principalTable: "TiposUnidadeEscolar",
                        principalColumn: "TipoUnidadeEscolarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnidadesEscolares_Regioes_UnidadeEscolarId",
                        column: x => x.UnidadeEscolarId,
                        principalTable: "Regioes",
                        principalColumn: "RegiaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItensCardapio",
                columns: table => new
                {
                    CardapioId = table.Column<int>(nullable: false),
                    ServicoId = table.Column<int>(nullable: false),
                    PratoId = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensCardapio", x => new { x.CardapioId, x.ServicoId, x.PratoId, x.Data });
                    table.ForeignKey(
                        name: "FK_ItensCardapio_Cardapios_CardapioId",
                        column: x => x.CardapioId,
                        principalTable: "Cardapios",
                        principalColumn: "CardapioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItensCardapio_Pratos_PratoId",
                        column: x => x.PratoId,
                        principalTable: "Pratos",
                        principalColumn: "PratoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItensCardapio_Servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servicos",
                        principalColumn: "ServicoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cardapios_AgrupamentoId",
                table: "Cardapios",
                column: "AgrupamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cardapios_TipoGestaoId",
                table: "Cardapios",
                column: "TipoGestaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensCardapio_PratoId",
                table: "ItensCardapio",
                column: "PratoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensCardapio_ServicoId",
                table: "ItensCardapio",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensServico_PratoId",
                table: "ItensServico",
                column: "PratoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pratos_GrupoPratoId",
                table: "Pratos",
                column: "GrupoPratoId");

            migrationBuilder.CreateIndex(
                name: "IX_Regioes_AgrupamentoId",
                table: "Regioes",
                column: "AgrupamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_UnidadesEscolares_TipoGestaoId",
                table: "UnidadesEscolares",
                column: "TipoGestaoId");

            migrationBuilder.CreateIndex(
                name: "IX_UnidadesEscolares_TipoUnidadeEscolarId",
                table: "UnidadesEscolares",
                column: "TipoUnidadeEscolarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensCardapio");

            migrationBuilder.DropTable(
                name: "ItensServico");

            migrationBuilder.DropTable(
                name: "UnidadesEscolares");

            migrationBuilder.DropTable(
                name: "Cardapios");

            migrationBuilder.DropTable(
                name: "Pratos");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "TiposUnidadeEscolar");

            migrationBuilder.DropTable(
                name: "Regioes");

            migrationBuilder.DropTable(
                name: "TiposGestao");

            migrationBuilder.DropTable(
                name: "Agrupamentos");
        }
    }
}
