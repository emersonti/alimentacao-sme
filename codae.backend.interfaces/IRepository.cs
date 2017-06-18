using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace codae.backend.interfaces
{
    public interface IRepository<TEntity> where TEntity: class
    {
        void Add(TEntity entidade);
        void Update(TEntity entidade);
        void Remove(object key);

        IEnumerable<TEntity> GetAll();
        TEntity GetByKey(object key);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        int SaveChanges();
    }
}
