using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using codae.backend.interfaces;

namespace codae.backend.data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity: class
    {
        public void Add(TEntity entidade)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public TEntity GetByKey(object key)
        {
            throw new NotImplementedException();
        }

        public void Remove(object key)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entidade)
        {
            throw new NotImplementedException();
        }
    }
}