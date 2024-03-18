using System.Linq.Expressions;

namespace Cepedi.Data.Repositories;
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task Post(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate);  
    }
