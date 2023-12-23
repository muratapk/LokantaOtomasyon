using BusinessLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Entities;
using DataAccessLayer.Data;

namespace DataAccessLayer.Repository
{
    public class PersonellerRepository:GenericRepository<Personeller>,IPersonellerRepository
    {
        private readonly ApplicationDbContext _context;

        public PersonellerRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();

        }
    }
}
