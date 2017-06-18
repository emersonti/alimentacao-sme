using System;
using codae.backend.core.Models;
using codae.backend.data.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace codae.backend.data.Mappings
{
    public class UnidadeEscolarMapping : EntityTypeConfiguration<UnidadeEscolar>
    {
        public override void Map(EntityTypeBuilder<UnidadeEscolar> builder)
        {

            builder.Property(u => u.Nome)
                .HasColumnType("VARCHAR(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(u => u.TipoUnidadeEscolar)
                .WithMany()
                .HasForeignKey(u => u.TipoUnidadeEscolarId)
                .IsRequired();

            builder.HasOne(u => u.TipoGestao)
                .WithMany()
                .HasForeignKey(u => u.TipoGestaoId)
                .IsRequired();

            builder.HasOne(u => u.Regiao)
                .WithMany()
                .HasForeignKey(u => u.UnidadeEscolarId)
                .IsRequired();

            builder.ToTable("UnidadesEscolares");
        }
    }
}
