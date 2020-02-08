using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace DataAccessLayer.Repository
{

    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        IQueryable<T> GetAll();
        IQueryable<T> AllIncludingDelete();
        T GetById(int id);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T oldEntity, T newEntity);
        void HardDelete(T entity);
    }
}
