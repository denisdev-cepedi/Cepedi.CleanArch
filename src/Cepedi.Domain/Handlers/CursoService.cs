using Cepedi.Domain.Entities;
using Cepedi.Domain.Repository;
using Cepedi.Domain.Services;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;

namespace Cepedi.Domain.Handlers;
public class CursoService : ICursoService
{
    private readonly ICursoRepository _cursoRepository;
    private readonly IProfessorRepository _professorRepository;
    public CursoService(ICursoRepository cursoRepository, IProfessorRepository professorRepository)
    {
        _cursoRepository = cursoRepository;
        _professorRepository = professorRepository;
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

    public async Task<CursoEntity> Create(CriaCursoRequest request, CancellationToken cancellationToken = default)
    {
        var professor = await _professorRepository.GetById(request.ProfessorId, cancellationToken);

        if (professor == null)
        {
            throw new KeyNotFoundException($"Professor with id {request.ProfessorId} not found.");
        }

        var curso = new CursoEntity(){
            Nome = request.Nome,
            Descricao = request.Descricao,
            DataInicio = request.DataInicio,
            DataFim = request.DataFim,
            ProfessorId = request.ProfessorId
        };
        return await _cursoRepository.Create(curso, cancellationToken);
        // return new ObtemCursoResponse(curso.Nome, $"{curso.DataInicio} - {curso.DataFim}", curso.Professor.Nome);
    }

    public async Task<ObtemCursoResponse> Update(int cursoId, CriaCursoRequest request, CancellationToken cancellationToken = default)
    {
        var professor = await _professorRepository.GetById(request.ProfessorId, cancellationToken);

        if (professor == null)
        {
            throw new KeyNotFoundException($"Professor with id {request.ProfessorId} not found.");
        }

        var curso = new CursoEntity(){
            Id = cursoId,
            Nome = request.Nome,
            Descricao = request.Descricao,
            DataInicio = request.DataInicio,
            DataFim = request.DataFim,
            ProfessorId = request.ProfessorId
        };

        await _cursoRepository.Update(curso, cancellationToken);
        return new ObtemCursoResponse(curso.Nome, $"{curso.DataInicio} - {curso.DataFim}", curso.Professor.Nome);
    }

    public async Task Delete(int id, CancellationToken cancellationToken = default)
    {
        await _cursoRepository.Delete(id, cancellationToken);
    }
}
