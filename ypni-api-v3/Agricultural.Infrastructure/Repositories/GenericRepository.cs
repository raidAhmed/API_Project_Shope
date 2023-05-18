using Agricultural.Application.Interfaces.Repositorys;

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore.Query;

namespace Agricultural.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        //replace DbContex with ApplicationDbContext
        public ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;

        }

        public virtual IQueryable<T> Entities => _context.Set<T>().AsNoTracking();

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }


        public virtual async Task<IEnumerable<T>> GetAll(int skip, int take)
        {
            return await _context.Set<T>().Skip(skip).Take(take).ToListAsync();
        }

        public virtual async Task<IEnumerable<R>> GetAll<R>(Expression<Func<T, R>> selector)
        {
            return await _context.Set<T>().Select(selector).ToListAsync();
        }
        public virtual async Task<IEnumerable<T>> MyGetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<IEnumerable<R>> GetAll<R>(Expression<Func<T, R>> selector, int skip, int take)
        {
            return await _context.Set<T>().Select(selector).Skip(skip).Take(take).ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression, int skip, int take)
        {
            return await _context.Set<T>().Where(expression).Skip(skip).Take(take).ToListAsync();
        }

        public virtual async Task<IEnumerable<R>> Find<R>(Expression<Func<T, R>> selector, Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).Select(selector).ToListAsync();
        }

        public virtual async Task<IEnumerable<R>> Find<R>(Expression<Func<T, R>> selector, Expression<Func<T, bool>> expression, int skip, int take)
        {
            return await _context.Set<T>().Where(expression).Select(selector).Skip(skip).Take(take).ToListAsync();
        }

        public virtual async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }
        public virtual void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);

        }
        public virtual void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public async Task<T> AddAndReturn(T entity)
        {
            var result = await _context.Set<T>().AddAsync(entity);

            return result.Entity;
        }
        public T RemoveAndReturn(T entitiy)
        {
            var res = _context.Set<T>().Remove(entitiy);
            return res.Entity;

        }
        public async Task<T?> GetById(int Id)
        {
            return await _context.Set<T>().FindAsync(Id);
        }

        public List<T> Addlist(List<T> entity)
        {
            // List<T> M = new List<T>();
            _context.AddRange(entity);
            return (entity).ToList();
        }
        //public async Task<List<T>> FindAllwinclude(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        //{
        //    IQueryable<T> query = _dbb;
        //    if (expression != null)
        //    {
        //        query = query.Where(expression);
        //    }
        //    if (includes != null)
        //    {
        //        query = includes(query);
        //    }
        //    return await query.ToListAsync();
        //}
        //public IList<R> GetAllmvcc<R>(Expression<Func<T, R>> selector)
        //{
        //    return  _context.Set<T>().Select(selector).ToList();
        //}
    }
}
