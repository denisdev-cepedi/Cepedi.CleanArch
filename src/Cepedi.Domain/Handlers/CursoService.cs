using Cepedi.Domain.Repository;
using Cepedi.Domain.Services;
using Cepedi.Shareable.Responses;

namespace Cepedi.Domain.Handlers;
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
        var horario = $"{curso.DataInicio} - {curso.DataFim}";
        return new ObtemCursoResponse(curso.Nome, horario, curso.Professor.Nome);
    }

    public async Task<IEnumerable<ObtemCursoResponse>> GetAll(CancellationToken cancellationToken = default)
    {
        var cursos = await _cursoRepository.GetAll(cancellationToken);
        return cursos.Select(c => new ObtemCursoResponse(c.Nome, $"{c.DataInicio} - {c.DataFim}", c.Professor.Nome));
    }

}
