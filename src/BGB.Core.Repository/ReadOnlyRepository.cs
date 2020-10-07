﻿using BGB.Core.Repository.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using NHibernate;

namespace BGB.Core.Repository
{
    public abstract class ReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : class
    {

        #region [ Session ]

        protected ISession Session
        {
            get { return SessionManager.GetCurrentSession(); }
        }

        #endregion [ Session ]

        #region [ Count ]

        /// <summary>
        /// Returns the number of records
        /// </summary>
        /// <param name="expression">Expression used in the query</param>
        /// <returns>Number of records</returns>
        protected int Count(Expression<Func<TEntity, bool>> expression)
        {
            return Session.Query<TEntity>().Where(expression).Count();
        }

        /// <summary>
        /// Returns the number of records
        /// </summary>
        /// <param name="expressions">Expression used in the query</param>
        /// <returns>Number of records</returns>
        protected int Count(IList<Expression<Func<TEntity, bool>>> expressions)
        {
            var query = Session.Query<TEntity>();

            query = expressions.Aggregate(query, (current, item) => current.Where(item));

            return query.Count();
        }

        #endregion [ Count ]

        #region [ Load ]

        public IEnumerable<TEntity> LoadAll()
        {
            return Session.CreateCriteria(typeof(TEntity)).List<TEntity>().ToList();
        }

        public TEntity LoadById(int id, bool @readonly = true)
        {
            if (@readonly)
                return Session.Get<TEntity>(id);
            else
                return Session.Load<TEntity>(id);
        }

        public TEntity LoadById(long id, bool @readonly = true)
        {
            if (@readonly)
                return Session.Get<TEntity>(id);
            else
                return Session.Load<TEntity>(id);
        }

        public TEntity LoadById(string id, bool @readonly = true)
        {
            if (@readonly)
                return Session.Get<TEntity>(id);
            else
                return Session.Load<TEntity>(id);
        }

        #endregion [ Load ]

        #region [ Load by filter paged ]

        /// <summary>
        /// Returns a list of entities by filter paging
        /// </summary>
        /// <param name="expression">Expression used in the query</param>
        /// <param name="start">Amount of the jump</param>
        /// <param name="limit">Number of records</param>
        /// <param name="rowCount">Total of records</param>
        /// <returns>List of entities</returns>
        protected IEnumerable<TEntity> LoadByFilterPaged(Expression<Func<TEntity, bool>> expression, int start, int limit, out int rowCount)
        {
            rowCount = Count(expression);
            return Session.Query<TEntity>().Where(expression).Skip(limit * (start - 1)).Take(limit).ToList();
        }

        /// <summary>
        /// Returns a list of entities by filter paging
        /// </summary>
        /// <param name="expression">Expression used in the query</param>
        /// <param name="order">Expression used in the query</param>
        /// <param name="start">Amount of the jump</param>
        /// <param name="limit">Number of records</param>
        /// <param name="rowCount">Total of records</param>
        /// <returns>List of entities</returns>
        protected IEnumerable<TEntity> LoadByFilterPaged(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, object>> order, int start, int limit, out int rowCount)
        {
            rowCount = Count(expression);
            return Session.Query<TEntity>().Where(expression).OrderBy(order).Skip(limit * (start - 1)).Take(limit).ToList();
        }

        /// <summary>
        /// Returns a list of entities by filter paging
        /// </summary>
        /// <param name="expression">Expression used in the query</param>
        /// <param name="order">Expression used in the query</param>
        /// <param name="start">Amount of the jump</param>
        /// <param name="limit">Number of records</param>
        /// <param name="rowCount">Total of records</param>
        /// <returns>List of entities</returns>
        protected IEnumerable<TEntity> LoadByFilterPagedDescending(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, object>> order, int start, int limit, out int rowCount)
        {
            rowCount = Count(expression);
            return Session.Query<TEntity>().Where(expression).OrderByDescending(order).Skip(limit * (start - 1)).Take(limit).ToList();
        }

        /// <summary>
        /// Returns a list of entities by filter paging
        /// </summary>
        /// <param name="expressions">Expression used in the query</param>
        /// <param name="start">Amount of the jump</param>
        /// <param name="limit">Number of records</param>
        /// <param name="rowCount">Total of records</param>
        /// <returns>List of entities</returns>
        protected IEnumerable<TEntity> LoadByFilterPaged(IList<Expression<Func<TEntity, bool>>> expressions, int start, int limit, out int rowCount)
        {
            rowCount = Count(expressions);

            var query = Session.Query<TEntity>();
            query = expressions.Aggregate(query, (current, item) => current.Where(item));

            return query.Skip(limit * (start - 1)).Take(limit).ToList();
        }

        /// <summary>
        /// Returns a list of entities by filter paging
        /// </summary>
        /// <param name="expressions">Expression used in the query</param>
        /// <param name="order">Expression used in the query</param>
        /// <param name="start">Amount of the jump</param>
        /// <param name="limit">Number of records</param>
        /// <param name="rowCount">Total of records</param>
        /// <returns>List of entities</returns>
        protected IEnumerable<TEntity> LoadByFilterPaged(IList<Expression<Func<TEntity, bool>>> expressions, Expression<Func<TEntity, object>> order, int start, int limit, out int rowCount)
        {
            rowCount = Count(expressions);

            var query = Session.Query<TEntity>();
            query = expressions.Aggregate(query, (current, item) => current.Where(item));

            return query.OrderBy(order).Skip(limit * (start - 1)).Take(limit).ToList();
        }

        /// <summary>
        /// Returns a list of entities by filter paging
        /// </summary>
        /// <param name="expressions">Expression used in the query</param>
        /// <param name="order">Expression used in the query</param>
        /// <param name="start">Amount of the jump</param>
        /// <param name="limit">Number of records</param>
        /// <param name="rowCount">Total of records</param>
        /// <returns>List of entities</returns>
        protected IEnumerable<TEntity> LoadByFilterPagedDescending(IList<Expression<Func<TEntity, bool>>> expressions, Expression<Func<TEntity, object>> order, int start, int limit, out int rowCount)
        {
            rowCount = Count(expressions);

            var query = Session.Query<TEntity>();
            query = expressions.Aggregate(query, (current, item) => current.Where(item));

            return query.OrderByDescending(order).Skip(limit * (start - 1)).Take(limit).ToList();
        }

        #endregion [ Load by filter paged ]

        #region [ Load by filter ]

        /// <summary>
        /// Returns a list of entities by filter
        /// </summary>
        /// <param name="expression">Expression used in the query</param>
        /// <returns>List of entities</returns>
        protected IEnumerable<TEntity> LoadByFilter(Expression<Func<TEntity, bool>> expression)
        {
            return Session.Query<TEntity>().Where(expression).ToList();
        }

        /// <summary>
        /// Returns a list of entities by filter
        /// </summary>
        /// <param name="expression">Expression used in the query</param>
        /// <param name="order">Expression used in the query</param>
        /// <returns>List of entities</returns>
        protected IEnumerable<TEntity> LoadByFilter(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, object>> order)
        {
            return Session.Query<TEntity>().Where(expression).OrderBy(order).ToList();
        }

        /// <summary>
        /// Returns a list of entities by filter
        /// </summary>
        /// <param name="expression">Expression used in the query</param>
        /// <param name="order">Expression used in the query</param>
        /// <returns>List of entities</returns>
        protected IEnumerable<TEntity> LoadByFilterDescending(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, object>> order)
        {
            return Session.Query<TEntity>().Where(expression).OrderByDescending(order).ToList();
        }

        /// <summary>
        /// Returns a list of entities by filter
        /// </summary>
        /// <param name="expressions">Expression used in the query</param>
        /// <returns>List of entities</returns>
        protected IEnumerable<TEntity> LoadByFilter(IList<Expression<Func<TEntity, bool>>> expressions)
        {
            var query = Session.Query<TEntity>();

            query = expressions.Aggregate(query, (current, item) => current.Where(item));

            return query.ToList();
        }

        /// <summary>
        /// Returns a list of entities by filter
        /// </summary>
        /// <param name="expressions">Expression used in the query</param>
        /// <param name="order">Expression used in the query</param>
        /// <returns>List of entities</returns>
        protected IEnumerable<TEntity> LoadByFilter(IList<Expression<Func<TEntity, bool>>> expressions, Expression<Func<TEntity, object>> order)
        {
            var query = Session.Query<TEntity>();

            query = expressions.Aggregate(query, (current, item) => current.Where(item));

            return query.OrderBy(order).ToList();
        }

        /// <summary>
        /// Returns a list of entities by filter
        /// </summary>
        /// <param name="expressions">Expression used in the query</param>
        /// <param name="order">Expression used in the query</param>
        /// <returns>List of entities</returns>
        protected IEnumerable<TEntity> LoadByFilterDescending(IList<Expression<Func<TEntity, bool>>> expressions, Expression<Func<TEntity, object>> order)
        {
            var query = Session.Query<TEntity>();

            query = expressions.Aggregate(query, (current, item) => current.Where(item));

            return query.OrderByDescending(order).ToList();
        }

        #endregion [ Load by filter ]

    }
}