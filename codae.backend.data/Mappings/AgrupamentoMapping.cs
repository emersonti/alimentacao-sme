using System;
using codae.backend.core.Models;
using codae.backend.data.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace codae.backend.data.Mappings
{
    public class AgrupamentoMapping : EntityTypeConfiguration<Agrupamento>
    {
        public override void Map(EntityTypeBuilder<Agrupamento> builder)
        {
            builder.Property(a => a.Nome)
                .HasColumnType("VARCHAR(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.ToTable("Agrupamentos");
        }
    }
}
