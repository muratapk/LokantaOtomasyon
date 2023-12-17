using BusinessLayer.Common;
using DataAccessLayer.Data;
using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> sorgu = _context.Set<T>();
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
            return sorgu.ToList();
        }

        public T GetId(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> sorgu = _context.Set<T>();
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

        public void Update(T entity)
        {
           _context.Update(entity);
        }
    }
}
