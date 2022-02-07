using Arvind.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Arvind.Contract
{
    public interface IRepositoryBase<T> where T:class,IEntity
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
