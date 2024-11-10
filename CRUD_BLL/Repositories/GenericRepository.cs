using CRUD_BLL.Interfaces;
using CRUD_DAL.Contexts;
using CRUD_DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_BLL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private readonly CRUDAppDbContext _context;

        public GenericRepository(CRUDAppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(T item)
        {
            await _context.Set<T>().AddAsync(item);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(T item)
        {
            _context.Set<T>().Remove(item);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            if (typeof(T) == typeof(Employee))
                return (IEnumerable<T>)await _context.Set<Employee>().Include(E => E.Department).ToListAsync();

            return await _context.Set<T>().ToListAsync();
        }


        public async Task<T> Get(int id)
        {
            if (typeof(T) == typeof(Employee))
                return await _context.Set<Employee>().Include(E => E.Department).FirstOrDefaultAsync(e=>e.Id == id) as T;

            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<int> Update(T item)
        {
            _context.Set<T>().Update(item);
            return await _context.SaveChangesAsync();
        }
    }
}
