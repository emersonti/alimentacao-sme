using System;
using codae.backend.core.Models;
using codae.backend.data.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace codae.backend.data.Mappings
{
    public class CardapioMapping : EntityTypeConfiguration<Cardapio>
    {
        public override void Map(EntityTypeBuilder<Cardapio> builder)
        {
            builder.Property(c => c.DataInicioVigencia)
                .IsRequired();

            builder.Property(c => c.DataTerminoVigencia)
                .IsRequired();

            builder.HasOne(c => c.Agrupamento)
                .WithMany()
                .HasForeignKey(c => c.AgrupamentoId)
                .IsRequired();

            builder.HasOne(c => c.Tipogestao)
                .WithMany()
                .HasForeignKey(c => c.TipoGestaoId)
                .IsRequired();

            builder.HasMany(c => c.ItensCardapio)
                .WithOne()
                .HasForeignKey(i => i.CardapioId)
                .IsRequired();

            builder.ToTable("Cardapios");
        }
    }
}
