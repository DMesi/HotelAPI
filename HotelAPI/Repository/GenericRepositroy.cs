using HotelAPI.Data;
using HotelAPI.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelAPI.Repository
{
    public class GenericRepositroy<T> : IGenericRepositroy<T> where T : class
    {
        private readonly DataBase _context;
        private readonly DbSet<T> _db;

        public GenericRepositroy(DataBase context) 
        {
            _context = context;
            _db = _context.Set<T>(); 
        }


        





        public async Task Delete(int id)
        {
            var entity = await _db.FindAsync(id);
            _db.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _db.RemoveRange(entities);
        }

        public async Task<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> expression, List<string> includes = null)
        {
            IQueryable<T> query = _db;
            if(includes != null)
            {
                foreach(var includePropery in includes)
                {
                    query = query.Include(includePropery);
                }

            }
            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<IList<T>> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> expresson = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null)
        {
            IQueryable<T> query = _db;

            if(expresson != null)
            {
                query = query.Where(expresson);

            }


            if (includes != null)
            {
                foreach (var includePropery in includes)
                {
                    query = query.Include(includePropery);
                }

            }

            if (orderBy != null)
            {

                query = orderBy(query); 
            }



                return await query.AsNoTracking().ToListAsync();


        }

        public async Task Insert(T entity)
        {
            await _db.AddAsync(entity);
        }

        public async Task InsertRange(IEnumerable<T> entities)
        {
            await _db.AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
            _db.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
