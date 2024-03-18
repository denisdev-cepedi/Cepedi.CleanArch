using Cepedi.Data.Repositories;
using Cepedi.Domain.Entities;
using Cepedi.Shareable.Responses;

namespace Cepedi.Data.Services;
public class CursoService : ICursoService
{
    private readonly ICursoRepository _cursoRepository;
    public CursoService(ICursoRepository cursoRepository)
    {
        _cursoRepository = cursoRepository;
    }
    public async Task<ObtemCursoResponse> GetById(int id, CancellationToken cancellationToken = default)
    {
        var curso = await _cursoRepository.GetById(id, cancellationToken);
        return new ObtemCursoResponse(curso.Nome, curso.DataInicio.ToString(), curso.Professor.Nome);
    }

}
