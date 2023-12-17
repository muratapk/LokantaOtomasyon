using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Entities;
namespace BusinessLayer.Common
{
    public interface IKategoriler
    {
        void Add(Kategoriler entity);
        void Delete(Kategoriler entity);
        void Update(Kategoriler entity);
       // void GetAll();
        //void GetId(int id);
        IEnumerable<Kategoriler>GetAll(Expression<Func<Kategoriler, bool>>? filter=null,string? includeProperties=null);
         Kategoriler GetId(Expression<Func<Kategoriler, bool>>filter, string? includeProperties = null);
        void Save();
    }
}
