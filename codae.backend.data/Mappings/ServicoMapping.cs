using System;
using codae.backend.core.Models;
using codae.backend.data.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace codae.backend.data.Mappings
{
    public class ServicoMapping : EntityTypeConfiguration<Servico>
    {
        public override void Map(EntityTypeBuilder<Servico> builder)
        {
            builder.Property(s => s.Nome)
                .HasColumnType("VARCHAR(100)")
                .HasMaxLength(100)
                .IsRequired();

            var navigation = builder.Metadata.FindNavigation(nameof(Servico.Composicao));
            navigation.SetPropertyAccessMode(Microsoft.EntityFrameworkCore.Metadata.PropertyAccessMode.Field);

            builder.HasMany(s => s.Composicao)                
                .WithOne(i => i.Servico)
                .HasForeignKey(i => i.ServicoId)
                .IsRequired();                

            builder.ToTable("Servicos");
        }
    }
}
