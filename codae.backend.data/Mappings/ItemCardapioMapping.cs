using System;
using codae.backend.core.Models;
using codae.backend.data.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace codae.backend.data.Mappings
{
    public class ItemCardapioMapping : EntityTypeConfiguration<ItemCardapio>
    {
        public override void Map(EntityTypeBuilder<ItemCardapio> builder)
        {
            builder.Property(i => i.Data)
                .IsRequired();

            builder.HasOne(i => i.Servico)
                .WithMany()
                .HasForeignKey(i => i.ServicoId)
                .IsRequired();

            builder.HasOne(i => i.Prato)
                .WithMany()
                .HasForeignKey(i => i.PratoId)
                .IsRequired();

            builder.HasKey(i => new { i.CardapioId, i.ServicoId, i.PratoId, i.Data });

            builder.ToTable("ItensCardapio");
        }
    }
}
