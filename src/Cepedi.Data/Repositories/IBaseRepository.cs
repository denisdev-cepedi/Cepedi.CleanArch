namespace Cepedi.Data.Repositories;

public interface IBaseRepository<T> where T : class
{
    Task<T> Get(int id, CancellationToken cancellationToken);
}