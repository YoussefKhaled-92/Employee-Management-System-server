using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
namespace MyTask.DAL
{
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : DomainObject
    {

        #region Constructors

        protected RepositoryBase(ApplicationDbContext context)
        {
            _entities = context.Set<TEntity>();
        }

        #endregion

        #region Properties

        private readonly DbSet<TEntity> _entities;

        #endregion

        #region Methods

        public virtual IQueryable<TEntity> GetAll()
        {
            return _entities;
        }

        public virtual TEntity GetById(int id)
        {
            return _entities.Find(id);
        }

        public virtual void Add(TEntity entity)
        {
            _entities.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {

        }

        public virtual void Delete(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public virtual void Delete(int id)
        {
            TEntity entity = GetById(id);
            if (entity != null)
            {
                Delete(entity);
            }
        }
        #endregion

    }
}
