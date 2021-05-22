using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MyAnime_DAL.Data.Repositories
{
    //info gathered from course 
    public interface IRepository<T>
       where T : class, new()
    {
        IEnumerable<T> Get();
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);

        IEnumerable<T> Get(Expression<Func<T, bool>> conditions);
        IEnumerable<T> Get(params Expression<Func<T, object>>[] includes);
        IEnumerable<T> Get(Expression<Func<T, bool>> conditions,
            params Expression<Func<T, object>>[] includes);
        /*IEnumerable<T> GetSingle(Expression<Func<T, bool>> conditions, 
            params Expression<Func<T, object>>[] includes);*/
        T SearchWithPK<TPrimaryKey>(TPrimaryKey id);

        void CreateOrUpdate(T entity);
        void CreateRange(IEnumerable<T> entities);
        void Delete<TPrimaryKey>(TPrimaryKey id);
        void DeleteRange(IEnumerable<T> entities);
    }
}
