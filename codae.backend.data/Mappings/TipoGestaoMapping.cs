using System;
using codae.backend.core.Models;
using codae.backend.data.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace codae.backend.data.Mappings
{
    public class TipoGestaoMapping : EntityTypeConfiguration<TipoGestao>
    {
        public override void Map(EntityTypeBuilder<TipoGestao> builder)
        {
            builder.Property(t => t.Nome)
                .HasColumnType("VARCHAR(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.ToTable("TiposGestao");
        }
    }
}
