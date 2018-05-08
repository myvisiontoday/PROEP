using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace IManageService.BusinessLogic.Repostiories
{
    /// <summary>
    /// An interface for a class capable of providing basic search and find
    /// </summary>
    /// <typeparam name="TEntity">TEntity is generic type of a class</typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Adds an entity
        /// </summary>
        /// <param name="entity">TEntity is generic type of a class</param>
        void Add(TEntity entity);

        /// <summary>
        /// Adds an entities in a range
        /// </summary>
        /// <param name="entities"></param>
        void AddRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Finds entities with given predicate
        /// </summary>
        /// <param name="predicate">A method which has parameter and returns true or flase when executed</param>
        /// <returns>List of TEntity with given predicate</returns>
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Finds an entity with given predicate
        /// </summary>
        /// <param name="predicate">A method which has parameter and returns true or flase when executed</param>
        /// <returns>TEntity with given predicate otherwise null</returns>
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Finds an entity with given id
        /// </summary>
        /// <param name="id">An id of an entity</param>
        /// <returns></returns>
        TEntity Get(int id);

        /// <summary>
        /// Gets entities
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Removes an entity
        /// </summary>
        /// <param name="entity">Entity to be removed</param>
        void Remove(TEntity entity);

        /// <summary>
        /// Removes entities in  a range
        /// </summary>
        /// <param name="entities">List of an entity</param>
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
