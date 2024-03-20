using Cepedi.Domain.Entities;
using Cepedi.Shareable;

namespace Cepedi.Domain;

public class InserirCursoHandler : IInserirCursoHandler
{
    private readonly ICursoRepository _cursoRepository;
    public InserirCursoHandler(ICursoRepository cursoRepository)
    {
        _cursoRepository = cursoRepository;
    }

    public async Task<CursoEntity> InserirCursoAsync(CursoDto curso)
    {
        return await _cursoRepository.InserirCursoAsync(curso);
    }
}
