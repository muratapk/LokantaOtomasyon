using BusinessLayer.Common;
using DataAccessLayer.Data;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class RollerRepository : GenericRepository<Roller>, IRollerRepository
    {
       private readonly ApplicationDbContext _context;

        public RollerRepository(ApplicationDbContext context):base(context) 
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges(); 
        }
    }
}
