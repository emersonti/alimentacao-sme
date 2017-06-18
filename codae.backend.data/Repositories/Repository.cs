using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using codae.backend.interfaces;
using Microsoft.EntityFrameworkCore;
using codae.backend.data.Contexts;
using System.Linq;

namespace codae.backend.data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity: class
    {
        protected readonly CODAEContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(CODAEContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public IEnumerable<TEntity> GetAll()
        {
                return _dbSet.ToList();
        }

        public TEntity GetByKey(object key)
        {
                return _dbSet.Find(key);
        }

        public void Remove(object key)
        {
                _dbSet.Remove(_dbSet.Find(key));
        }

        public int SaveChanges()
        {
                return _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
                _dbSet.Update(entity);
        }
    }
}