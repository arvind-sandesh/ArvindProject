using Arvind.Contract;
using Arvind.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Arvind.Repository
{
    public abstract class RepositoryBase<T, TContext> : IRepositoryBase<T> 
        where T : class, IEntity 
        where TContext : DbContext
    {
        private readonly TContext context;
        public RepositoryBase(TContext context)
        {
            this.context = context;
        }
        public void Create(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll()
        {
            return context.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().Where(expression).AsNoTracking();
        }

        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
        }
    }
}
