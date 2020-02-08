using DataAccessLayer;
using DataAccessLayer.Database;
using DataAccessLayer.Infrastructure;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace DataAccessLayer.Repository
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T>
            where T : class, IEntityBase, new()
    {

        private DBContext dataContext;

        #region Properties
        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected DBContext DbContext
        {
            get { return dataContext ?? (dataContext = DbFactory.Init()); }
        }
        public EntityBaseRepository(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
        }
        #endregion
        public virtual IQueryable<T> GetAll() => DbContext.Set<T>().Where(x => x.IsDeleted != true);
        public virtual IQueryable<T> AllIncludingDelete() => DbContext.Set<T>();

        public T GetById(int id)
        {
            return GetAll().FirstOrDefault(a => a.Id == id);//changes
        }

        public virtual void Add(T entity)
        {
            DbContext.Set<T>().AddAsync(entity);
            DbContext.SaveChangesAsync();
        }

        public virtual void Edit(T oldEntity, T newEntity)
        {
            DbContext.Entry(oldEntity).CurrentValues.SetValues(newEntity);
        }
        public virtual void Delete(T entity)
        {
            entity.IsDeleted = true;
            EntityEntry dbEntityEntry = DbContext.Entry<T>(entity);
            dbEntityEntry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
        public virtual void HardDelete(T entity)
        {
            EntityEntry dbEntityEntry = DbContext.Entry(entity);
            dbEntityEntry.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }
    }
}
