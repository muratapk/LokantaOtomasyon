using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Common
{
    public interface IGenericRepository<T>where T:class
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        // void GetAll();
        //void GetId(int id);
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        T GetId(Expression<Func<T, bool>> filter, string? includeProperties = null);
        
    }
}
