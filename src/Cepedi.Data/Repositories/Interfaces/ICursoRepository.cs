using Cepedi.Domain.Entities;

namespace Cepedi.Data.Repositories.Interfaces;

public interface ICursoRepository
{
    public Task<CursoEntity> GetById(int id);
}
