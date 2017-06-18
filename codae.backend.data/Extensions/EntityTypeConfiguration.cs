using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace codae.backend.data.Extensions
{
    public abstract class EntityTypeConfiguration<TEntity> where TEntity : class
    {
        public abstract void Map(EntityTypeBuilder<TEntity> builder);
    }
}