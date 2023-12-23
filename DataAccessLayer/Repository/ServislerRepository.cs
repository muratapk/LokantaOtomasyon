using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Common;
using DataAccessLayer.Data;
using EntityLayer.Entities;
namespace DataAccessLayer.Repository
{
    public class ServislerRepository:GenericRepository<Servisler>,IServislerRepository
    {
        public readonly ApplicationDbContext _context;

        public ServislerRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
