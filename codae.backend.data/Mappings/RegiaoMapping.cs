using Microsoft.EntityFrameworkCore.Metadata.Builders;
using codae.backend.core.Models;
using codae.backend.data.Extensions;
using Microsoft.EntityFrameworkCore;

namespace codae.backend.data.Mappings
{
    public class RegiaoMapping : EntityTypeConfiguration<Regiao>
    {
        public override void Map(EntityTypeBuilder<Regiao> builder)
        {
            builder.Property(r => r.Nome)
                .HasColumnType("VARCHAR(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(r => r.Dirigente)                
                .HasColumnType("VARCHAR(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(r => r.Email)
                .HasColumnType("VARCHAR(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(r => r.Telefone)
                .HasColumnType("VARCHAR(20)")
                .HasMaxLength(20)
                .IsRequired();

            builder.HasOne(r => r.Agrupamento)
                .WithMany()
                .HasForeignKey(r => r.AgrupamentoId)
                .IsRequired();

            builder.ToTable("Regioes");
        }
    }
}