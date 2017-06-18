using System;
using codae.backend.data.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using codae.backend.core.Models;
using Microsoft.EntityFrameworkCore;

namespace codae.backend.data.Mappings
{
    public class TipoUnidadeEscolarMapping : EntityTypeConfiguration<TipoUnidadeEscolar>
    {
        public override void Map(EntityTypeBuilder<TipoUnidadeEscolar> builder)
        {
            builder.Property(t => t.Nome)
                .HasColumnType("VARCHAR(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.ToTable("TiposUnidadeEscolar");
        }
    }
}
