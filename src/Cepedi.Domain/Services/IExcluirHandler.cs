using Cepedi.Domain.Entities;

namespace Cepedi.Domain;

public interface IExcluirHandler
{
    public Task<CursoEntity> ExcluirAsync(int id);
}
