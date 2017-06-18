using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using codae.backend.data.Contexts;
using codae.backend.core.Models;

namespace codae.backend.data.Migrations
{
    [DbContext(typeof(CODAEContext))]
    [Migration("20170618061546_InitialDatabase")]
    partial class InitialDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("codae.backend.core.Models.Agrupamento", b =>
                {
                    b.Property<int>("AgrupamentoId");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasMaxLength(100);

                    b.HasKey("AgrupamentoId");

                    b.ToTable("Agrupamentos");
                });

            modelBuilder.Entity("codae.backend.core.Models.Cardapio", b =>
                {
                    b.Property<int>("CardapioId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AgrupamentoId");

                    b.Property<DateTime>("DataInicioVigencia");

                    b.Property<DateTime>("DataTerminoVigencia");

                    b.Property<int>("TipoGestaoId");

                    b.HasKey("CardapioId");

                    b.HasIndex("AgrupamentoId");

                    b.HasIndex("TipoGestaoId");

                    b.ToTable("Cardapios");
                });

            modelBuilder.Entity("codae.backend.core.Models.ItemCardapio", b =>
                {
                    b.Property<int>("CardapioId");

                    b.Property<int>("ServicoId");

                    b.Property<int>("PratoId");

                    b.Property<DateTime>("Data");

                    b.HasKey("CardapioId", "ServicoId", "PratoId", "Data");

                    b.HasIndex("PratoId");

                    b.HasIndex("ServicoId");

                    b.ToTable("ItensCardapio");
                });

            modelBuilder.Entity("codae.backend.core.Models.ItemServico", b =>
                {
                    b.Property<int>("ServicoId");

                    b.Property<int>("PratoId");

                    b.Property<string>("Nome")
                        .HasColumnType("VARCHAR(100)")
                        .HasMaxLength(100);

                    b.HasKey("ServicoId", "PratoId", "Nome");

                    b.HasIndex("PratoId");

                    b.ToTable("ItensServico");
                });

            modelBuilder.Entity("codae.backend.core.Models.Prato", b =>
                {
                    b.Property<int>("PratoId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("GrupoPratoId");

                    b.Property<string>("Nome");

                    b.HasKey("PratoId");

                    b.HasIndex("GrupoPratoId");

                    b.ToTable("Pratos");
                });

            modelBuilder.Entity("codae.backend.core.Models.Regiao", b =>
                {
                    b.Property<int>("RegiaoId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AgrupamentoId");

                    b.Property<string>("Dirigente")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)")
                        .HasMaxLength(20);

                    b.HasKey("RegiaoId");

                    b.HasIndex("AgrupamentoId");

                    b.ToTable("Regioes");
                });

            modelBuilder.Entity("codae.backend.core.Models.Servico", b =>
                {
                    b.Property<int>("ServicoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasMaxLength(100);

                    b.HasKey("ServicoId");

                    b.ToTable("Servicos");
                });

            modelBuilder.Entity("codae.backend.core.Models.TipoGestao", b =>
                {
                    b.Property<int>("TipoGestaoId");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasMaxLength(100);

                    b.HasKey("TipoGestaoId");

                    b.ToTable("TiposGestao");
                });

            modelBuilder.Entity("codae.backend.core.Models.TipoUnidadeEscolar", b =>
                {
                    b.Property<int>("TipoUnidadeEscolarId");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasMaxLength(100);

                    b.HasKey("TipoUnidadeEscolarId");

                    b.ToTable("TiposUnidadeEscolar");
                });

            modelBuilder.Entity("codae.backend.core.Models.UnidadeEscolar", b =>
                {
                    b.Property<int>("UnidadeEscolarId");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasMaxLength(100);

                    b.Property<int>("RegiaoId");

                    b.Property<int>("TipoGestaoId");

                    b.Property<int>("TipoUnidadeEscolarId");

                    b.HasKey("UnidadeEscolarId");

                    b.HasIndex("TipoGestaoId");

                    b.HasIndex("TipoUnidadeEscolarId");

                    b.ToTable("UnidadesEscolares");
                });

            modelBuilder.Entity("codae.backend.core.Models.Cardapio", b =>
                {
                    b.HasOne("codae.backend.core.Models.Agrupamento", "Agrupamento")
                        .WithMany()
                        .HasForeignKey("AgrupamentoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("codae.backend.core.Models.TipoGestao", "Tipogestao")
                        .WithMany()
                        .HasForeignKey("TipoGestaoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("codae.backend.core.Models.ItemCardapio", b =>
                {
                    b.HasOne("codae.backend.core.Models.Cardapio")
                        .WithMany("ItensCardapio")
                        .HasForeignKey("CardapioId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("codae.backend.core.Models.Prato", "Prato")
                        .WithMany()
                        .HasForeignKey("PratoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("codae.backend.core.Models.Servico", "Servico")
                        .WithMany()
                        .HasForeignKey("ServicoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("codae.backend.core.Models.ItemServico", b =>
                {
                    b.HasOne("codae.backend.core.Models.Prato", "Grupo")
                        .WithMany()
                        .HasForeignKey("PratoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("codae.backend.core.Models.Servico", "Servico")
                        .WithMany("Composicao")
                        .HasForeignKey("ServicoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("codae.backend.core.Models.Prato", b =>
                {
                    b.HasOne("codae.backend.core.Models.Prato", "GrupoPrato")
                        .WithMany()
                        .HasForeignKey("GrupoPratoId");
                });

            modelBuilder.Entity("codae.backend.core.Models.Regiao", b =>
                {
                    b.HasOne("codae.backend.core.Models.Agrupamento", "Agrupamento")
                        .WithMany()
                        .HasForeignKey("AgrupamentoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("codae.backend.core.Models.UnidadeEscolar", b =>
                {
                    b.HasOne("codae.backend.core.Models.TipoGestao", "TipoGestao")
                        .WithMany()
                        .HasForeignKey("TipoGestaoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("codae.backend.core.Models.TipoUnidadeEscolar", "TipoUnidadeEscolar")
                        .WithMany()
                        .HasForeignKey("TipoUnidadeEscolarId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("codae.backend.core.Models.Regiao", "Regiao")
                        .WithMany()
                        .HasForeignKey("UnidadeEscolarId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
