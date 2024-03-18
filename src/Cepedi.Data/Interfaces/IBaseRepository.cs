using System.Linq.Expressions;

namespace Cepedi.Data.Interfaces;
public interface IBaseRepository<T> where T : class
{
    IEnumerable<T> GetAll();
    T GetById(int id);
    Task Post(T entity);
    Task Put(T entity);
    Task Delete(T entity);
    IEnumerable<T> Search(Expression<Func<T, bool>> predicate);
}
