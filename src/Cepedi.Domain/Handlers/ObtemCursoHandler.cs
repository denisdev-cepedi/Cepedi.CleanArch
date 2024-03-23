using Cepedi.Domain.Repository;
using Cepedi.Domain.Services;
using Cepedi.Shareable.Responses;

namespace Cepedi.Domain.Handlers;

public class ObtemCursoHandler : IObtemCursoHandler
{
    private readonly ICursoRepository _cursoRepository;
    private readonly IProfessorRepository _professorRepository;

    public ObtemCursoHandler(ICursoRepository cursoRepository, IProfessorRepository professorRepository)
    {
        _cursoRepository = cursoRepository;
        _professorRepository = professorRepository;
    }

    public async Task<ObtemCursoResponse> ObtemCursoAsync(int idCurso)
    {
        var curso = await _cursoRepository.ObtemCursoPorIdAsync(idCurso);
        var professor = await _professorRepository.ObtemProfessorPorIdAsync(curso.ProfessorId);
        var horario = $"{curso.DataInicio} - {curso.DataFim}";
        return new ObtemCursoResponse(curso.Id, curso.Nome, horario, professor.Nome);
    }

    public async Task<IEnumerable<ObtemCursoResponse>> ObtemCursosAsync()
    {
        var cursos = await _cursoRepository.ObtemCursosAsync();

        var tasks = cursos.Select(async curso =>{
            var professor = await _professorRepository.ObtemProfessorPorIdAsync(curso.ProfessorId);
            var horario = $"{curso.DataInicio} - {curso.DataFim}";
            return new ObtemCursoResponse(curso.Id, curso.Nome, horario, professor.Nome);
        });
        return await Task.WhenAll(tasks);
    }

}
