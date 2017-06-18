using System;
using codae.backend.core.Models;
using codae.backend.data.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace codae.backend.data.Mappings
{
    public class PratoMapping : EntityTypeConfiguration<Prato>
    {
        public override void Map(EntityTypeBuilder<Prato> builder)
        {
            builder.HasOne(p => p.GrupoPrato)
                .WithMany()
                .HasForeignKey(p => p.GrupoPratoId)
                .IsRequired(false);              

            builder.ToTable("Pratos");
        }
    }
}
