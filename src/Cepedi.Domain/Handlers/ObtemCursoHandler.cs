using Cepedi.Shareable.Responses;

namespace Cepedi.Domain;

public class ObtemCursoHandler : IObtemCursoHandler
{
    private readonly ICursoRepository _cursoRepository;
    private readonly IProfessorRepository _professorRepository;

    public ObtemCursoHandler(
        ICursoRepository cursoRepository,
        IProfessorRepository professorRepository)
    {
        _cursoRepository = cursoRepository;
        _professorRepository = professorRepository;
    }

    public async Task<ObtemCursoResponse> ObterCursoAsync(int idCurso)
    {
        var curso = await _cursoRepository.ObtemCursoPorIdAsync(idCurso);

        var professor = await _professorRepository.ObtemProfessorPorIdAsync(curso.ProfessorId);

        var duracao = $"O curso tem duração de {curso.DataInicio} até {curso.DataFim}";

        return new ObtemCursoResponse(curso.Nome, duracao, professor.Nome);
    }
}
