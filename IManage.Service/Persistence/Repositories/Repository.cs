using IManageService.BusinessLogic.Repostiories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace IManageService.Persistence.Repositories
{
    /// <summary>
    /// A class which performs operations of Dbcontext
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region Protected Data
        /// <summary>
        /// Reference to a database context
        /// </summary>
        protected readonly DbContext DbContext;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes members
        /// </summary>
        /// <param name="dbContext"></param>
        public Repository(DbContext dbContext)
        {
            DbContext = dbContext;
        }
        #endregion

        #region IRepository Implementation
        public void Add(TEntity entity)
        {
            DbContext.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            DbContext.Set<TEntity>().AddRange(entities);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbContext.Set<TEntity>().Where(predicate);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return DbContext.Set<TEntity>().SingleOrDefault(predicate);
        }

        public TEntity Get(int id)
        {
            return DbContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DbContext.Set<TEntity>().ToList();
        }

        public void Remove(TEntity entity)
        {
            DbContext.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            DbContext.Set<TEntity>().RemoveRange(entities);
        }
        #endregion
    }
}
