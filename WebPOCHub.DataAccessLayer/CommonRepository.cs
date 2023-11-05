using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPOCHub.DataAccessLayer
{
    public class CommonRepository<T> : ICommonRepository<T> where T : class
    {
        private readonly DbContextClass _context;
        private DbSet<T> table;
        public CommonRepository(DbContextClass context)
        {
            _context = context;
            table = _context.Set<T>();
        }
        public void Delete(T item)
        {
            table.Remove(item);
        }

        public List<T> GetAll()
        {
            return table.ToList();
        }

        public T GetDetails(int id)
        {
            return table.Find(id);
        }

        public void Insert(T item)
        {
            table.Add(item);
        }

        public int SaveChanges()
        {
           return _context.SaveChanges();
        }

        public void Update(T item)
        {
            table.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
