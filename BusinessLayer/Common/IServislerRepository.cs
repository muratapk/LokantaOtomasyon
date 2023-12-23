using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Common
{
    public interface IServislerRepository:IGenericRepository<Servisler>
    {
        void Save();
    }
}
