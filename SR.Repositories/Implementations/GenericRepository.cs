using SR.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace SR.Repositories.Implementations
{
    public class GenericRepository<TEntity> 
        where TEntity : class
    {
        internal StudentsRegisterDbContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(StudentsRegisterDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null,
                                                   Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                   string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includePropery in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includePropery);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }

            return query.ToList();
        }

        public virtual TEntity GetById(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity item)
        {
            dbSet.Add(item);
        }

        public virtual void Delete(TEntity item)
        {
            dbSet.Remove(item);
        }

        public virtual void DeleteById(object id)
        {
            TEntity item = dbSet.Find(id);
            this.Delete(item);
        }

        public virtual void Update(TEntity item)
        {
            context.Entry(item).State = EntityState.Modified;
        }
    }
}