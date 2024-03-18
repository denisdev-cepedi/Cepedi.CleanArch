using Microsoft.EntityFrameworkCore;

namespace Cepedi.Data.Repositories;

public class BaseRepository<T>
{
    private readonly ApplicationDbContext _dbContext;

    public BaseRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // public async Task<T> GetById(int id)
    // {
    //     return await _dbContext.Set<T>().FirstOrDefaultAsync(entity => entity.Id == id);
    // }
}
