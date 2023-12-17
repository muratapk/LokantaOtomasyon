using BusinessLayer.Common;
using DataAccessLayer.Data;
using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class KategoryRepository : IKategoriler
    {
        private readonly ApplicationDbContext _context;

        public KategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Kategoriler entity)
        {
            _context.Add(entity);
        }

        public void Delete(Kategoriler entity)
        {
            _context.Remove(entity);
        }

        public IEnumerable<Kategoriler> GetAll(Expression<Func<Kategoriler, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<Kategoriler> sorgu = _context.Set<Kategoriler>();
            if (filter != null)
            {
                sorgu = sorgu.Where(filter);
            }
            if (string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeprop in includeProperties.Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries))
                {
                    sorgu = sorgu.Include(includeprop);
                }
               
            }
            return sorgu.ToList();
            
        }

        public Kategoriler GetId(Expression<Func<Kategoriler, bool>> filter, string? includeProperties = null)
        {
            IQueryable<Kategoriler> sorgu = _context.Set<Kategoriler>();
            if (filter != null)
            {
                sorgu = sorgu.Where(filter);
            }
            if (string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeprop in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    sorgu = sorgu.Include(includeprop);
                }

            }
            return sorgu.FirstOrDefault();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Kategoriler entity)
        {
            _context.Update(entity);
        }
    }
}
