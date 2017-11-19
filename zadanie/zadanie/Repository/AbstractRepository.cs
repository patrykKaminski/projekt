using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using zadanie.Models;

namespace zadanie.Repository
{
    public class AbstractRepository<T> where T : class
    {
        public virtual void Create(T entity)
        {
            using (var context = new AppDbContext())
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }
        }

        public virtual void Update(T entity)
        {
            using (var context = new AppDbContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public virtual List<T> GetWhere(Expression<Func<T, bool>> expression)
        {
            using (var context = new AppDbContext())
            {
                var query = context.Set<T>().Where(expression);
                return query.ToList();
            }
        }
        public virtual void Delete(T entity)
        {
            using (var context = new AppDbContext())
            {
                context.Set<T>().Remove(entity);
            }
        }
    }
}