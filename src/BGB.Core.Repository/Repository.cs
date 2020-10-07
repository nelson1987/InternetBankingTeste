using System;
using System.Collections.Generic;
using BGB.Core.Repository.Interfaces;

namespace BGB.Core.Repository
{
    public abstract class Repository<TEntity> : ReadOnlyRepository<TEntity>, IRepository<TEntity> where TEntity : class
    {

        #region [ CRUD operations ]

        /// <summary>	
        /// Saves entity	
        /// </summary>	
        /// <param name="t">Entity to save</param>"	
        public void Insert(TEntity t)
        {
            using (var tx = Session.BeginTransaction())
            {
                try
                {
                    //Save here	
                    Session.Save(t);
                    Session.Flush();
                    tx.Commit();
                }
                catch (Exception)
                {
                    tx.Rollback();
                    throw;
                }
            }
        }

        public void Insert(IList<TEntity> entities)
        {
            using (var tx = Session.BeginTransaction())
            {
                try
                {
                    foreach (TEntity t in entities)
                    {
                        Session.Save(t);
                    }

                    Session.Flush();

                    tx.Commit();
                }
                catch (Exception)
                {
                    tx.Rollback();
                    throw;
                }
            }
        }

        /// <summary>	
        /// Update entity	
        /// </summary>	
        /// <param name="t">Entity to save</param>"	
        public void Update(TEntity t)
        {
            using (var tx = Session.BeginTransaction())
            {
                try
                {
                    Session.Update(t);
                    Session.Flush();
                    tx.Commit();
                }
                catch (Exception)
                {
                    tx.Rollback();
                    throw;
                }
            }
        }

        public void Update(IList<TEntity> entities)
        {
            using (var tx = Session.BeginTransaction())
            {
                try
                {
                    foreach (TEntity t in entities)
                    {
                        Session.Update(t);
                    }

                    Session.Flush();

                    tx.Commit();
                }
                catch (Exception)
                {
                    tx.Rollback();
                    throw;
                }
            }
        }

        /// <summary>	
        /// Saves or updates entity	
        /// </summary>	
        /// <param name="t">Entity to save or update</param>"	
        public TEntity SaveOrUpdate(TEntity t)
        {
            using (var tx = Session.BeginTransaction())
            {
                try
                {
                    Session.SaveOrUpdate(t);
                    Session.Flush();
                    tx.Commit();
                }
                catch (Exception)
                {
                    tx.Rollback();
                    throw;
                }
            }

            return t;
        }

        /// <summary>	
        /// Deletes entity	
        /// </summary>	
        /// <param name="t">Entity to delete</param>"	
        public void Delete(TEntity t)
        {
            using (var tx = Session.BeginTransaction())
            {
                try
                {
                    Session.Delete(t);
                    Session.Flush();
                    tx.Commit();
                }
                catch (Exception)
                {
                    tx.Rollback();
                    throw;
                }
            }
        }

        public void Delete(IList<TEntity> entities)
        {
            using (var tx = Session.BeginTransaction())
            {
                try
                {
                    foreach (TEntity t in entities)
                    {
                        Session.Delete(t);
                    }

                    Session.Flush();
                    tx.Commit();
                }
                catch (Exception)
                {
                    tx.Rollback();
                    throw;
                }
            }
        }

        /// <summary>	
        /// Deletes entity	
        /// </summary>	
        /// <param name="id">identifier of the entity</param>"
        public void Delete(int id)
        {
            using (var tx = Session.BeginTransaction())
            {
                try
                {
                    Session.Delete(Session.Load<TEntity>(id));
                    Session.Flush();
                    tx.Commit();
                }
                catch (Exception)
                {
                    tx.Rollback();
                    throw;
                }
            }
        }

        /// <summary>	
        /// Deletes entity	
        /// </summary>	
        /// <param name="id">identifier of the entity</param>"
        public void Delete(long id)
        {
            using (var tx = Session.BeginTransaction())
            {
                try
                {
                    Session.Delete(Session.Load<TEntity>(id));
                    Session.Flush();
                    tx.Commit();
                }
                catch (Exception)
                {
                    tx.Rollback();
                    throw;
                }
            }
        }

        /// <summary>	
        /// Deletes entity	
        /// </summary>	
        /// <param name="id">identifier of the entity</param>"
        public void Delete(string id)
        {
            using (var tx = Session.BeginTransaction())
            {
                try
                {
                    Session.Delete(Session.Load<TEntity>(id));
                    Session.Flush();
                    tx.Commit();
                }
                catch (Exception)
                {
                    tx.Rollback();
                    throw;
                }
            }
        }

        #endregion [ CRUD operations ]

    }
}