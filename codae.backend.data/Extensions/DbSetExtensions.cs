using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace codae.backend.data.Extensions
{
    public static class DbSetExtensions
    {
        public static void AddOrUpdate<TEntity, kproperty>(this DbSet<TEntity> dbSet, TEntity entity, Expression<Func<TEntity, kproperty>> key)
            where TEntity: class
        {
            var value = key.Compile().DynamicInvoke(entity);
            var existent = dbSet.Find(value);
            if (value == null)                
                dbSet.Add(entity);
        }
    }
}