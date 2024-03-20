using System.Linq.Expressions;
using Cepedi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.Data.Repositories;
public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly ApplicationDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public BaseRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public virtual IEnumerable<T> GetAll()
    {
        return _dbSet.ToList();
    }
    public virtual T GetById(int id)
    {
        return _dbSet.Find(id);
    }

    public virtual async Task Post(T entity)
    {
        _dbSet.Add(entity);
    }

    public virtual async Task Put(T entity)
    {
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }

    public virtual async Task Delete(T entity)
    {
        if (_context.Entry(entity).State == EntityState.Detached)
            _dbSet.Attach(entity);

        _dbSet.Remove(entity);
    }

    public IEnumerable<T> Search(Expression<Func<T, bool>> predicate)
    {
        return _dbSet.AsNoTracking().Where(predicate).ToList();
    }

}
