using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using VinylStore.Entities;

namespace VinylStore.Repositories
{
    public class BaseRepository<T> where T : BaseEntity
    {
        protected DbContext context { get; set; }
        protected DbSet<T> items { get; set; }

        public BaseRepository()
        {
            context = new VinylStoreDbContext();
            items = context.Set<T>();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            return items.Where(filter).FirstOrDefault();
        }

        public T GetById(int id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = items;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query.Where(i => i.Id == id).FirstOrDefault();
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = items;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query.ToList();
        }

        public int Count(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = items;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.Count();
        }

        public void Insert(T item)
        {
            items.Add(item);
            context.SaveChanges();
        }

        public void Update(T item)
        {
            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(T item)
        {
            context.Entry(item).State = EntityState.Deleted;
            context.SaveChanges();
        }
    }
}