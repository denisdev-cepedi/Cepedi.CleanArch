using Cepedi.Domain.Entities;

namespace Cepedi.Domain;

public class ExcluirCursoHandler : IExcluirHandler
{
    private readonly ICursoRepository _cursoRepository;

    public ExcluirCursoHandler(ICursoRepository cursoRepository)
    {
        _cursoRepository = cursoRepository;
    }
    public async Task<CursoEntity> ExcluirAsync(int id)
    {
        return await _cursoRepository.ExcluirAsync(id);
    }
}
