namespace Cepedi.Data.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly ApplicationDbContext _context;

    public BaseRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<T> Get(int id, CancellationToken cancellationToken = default)
    {
        T? entity = await _context.Set<T>().FindAsync(id);

        if (entity == null)
        {
            throw new KeyNotFoundException($"Entity with id {id} not found.");
        }

        return entity;
    }

}