using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace MyAnime_DAL.Data.Repositories
{
    public class Repository<T> : IRepository<T>
       where T : class, new()
    {
        protected DbContext Context { get; }
        public Repository(DbContext context)
        {
            this.Context = context;
        }
        public IEnumerable<T> Get()
        {
            return Context.Set<T>().ToList();
        }
        public void Insert(T entity)
        {
            Context.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            Context.Entry<T>(entity).State = EntityState.Modified;
        }
        public void Delete(T entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
        }


        //uitbreiding

        public IEnumerable<T> Get(Expression<Func<T, bool>> conditions,
           params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = Context.Set<T>();
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }
            if (conditions != null)
            {
                query = query.Where(conditions);
            }
            return query.ToList();
        }
        /*public IEnumerable<T> GetSingle(Expression<Func<T, bool>> conditions, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = Context.Set<T>();
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }
            if (conditions != null)
            {
                query = query.Where(conditions);
            }
            return (IEnumerable<T>)query.SingleOrDefault();
        } */   
        public IEnumerable<T> Get(Expression<Func<T, bool>> conditions)
        {
            return Get(conditions, null).ToList();
        }

        public IEnumerable<T> Get(params Expression<Func<T, object>>[] includes)
        {
            return Get(null, includes).ToList();
        }




        //handige functies
        public T SearchWithPK<TPrimaryKey>(TPrimaryKey id)
        {
            return Context.Set<T>().Find(id);
        }
        public void CreateOrUpdate(T entity)
        {
            Context.Set<T>().AddOrUpdate(entity);
        }
        public void CreateRange(IEnumerable<T> entities)
        {
            Context.Set<T>().AddRange(entities);
        }
        public void Delete<TPrimaryKey>(TPrimaryKey id)
        {
            var entity = SearchWithPK(id);
            Context.Set<T>().Remove(entity);
        }
        public void DeleteRange(IEnumerable<T> entities)
        {
            Context.Set<T>().RemoveRange(entities);
        }
    }
}
