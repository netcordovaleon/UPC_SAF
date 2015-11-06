using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace SAF.AccesoDatos.Repository
{
    public interface IBaseRepository<T>
    {
        T GetById(object primaryKey);
        IEnumerable<T> GetAll();
        bool Exists(object primaryKey);
        T Add(T entity);
        T Update(T entity);
        void Delete(object id);
        T Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
        IEnumerable<T> GetMany(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
        IUnitOfWork UnitOfWork { get; }
        void UpdatePartial(dynamic entity, params Expression<Func<T, object>>[] property);
        void UpdatePartial(dynamic entity, string[] properties);
    }
}
