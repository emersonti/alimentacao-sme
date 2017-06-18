using System;
using codae.backend.core.Models;
using codae.backend.data.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace codae.backend.data.Mappings
{
    public class ItemServicoMapping : EntityTypeConfiguration<ItemServico>
    {
        public override void Map(EntityTypeBuilder<ItemServico> builder)
        {
            builder.Property(i => i.Nome)
                .HasColumnType("VARCHAR(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(i => i.Grupo)
                .WithMany()
                .HasForeignKey(i => i.PratoId)
                .IsRequired();

            builder.HasKey(i => new { i.ServicoId, i.PratoId, i.Nome });

            builder.ToTable("ItensServico");
        }
    }
}
