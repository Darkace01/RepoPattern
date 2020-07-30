using Data.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Data.Implementations
{
    public class CoreRepo<T> : ICoreRepo<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _DbSet;

        public CoreRepo(ApplicationDbContext context)
        {
            this._context = context;
            this._DbSet = this._context.Set<T>();
        }

        public void Add(T entity)
        {
            this._DbSet.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            this._DbSet.AddRange(entities);
        }

        public void Delete(T entity)
        {
            this._DbSet.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return this._DbSet.ToList();
        }
        public T Get(object id)
        {
            return _DbSet.Find(id);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _DbSet.Where(predicate);
        }

        public void Update(T entity)
        {
            this._DbSet.Attach(entity);
            this._context.Entry(entity).State = EntityState.Modified;
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                Update(entity);
            }

        }
    }
}
