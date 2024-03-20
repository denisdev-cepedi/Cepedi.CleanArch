using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;

namespace Cepedi.Domain;

public class AtualizaCursoHandler : IAtualizaCursoHandler
{
    private readonly ICursoRepository _cursoRepository;
    private readonly IProfessorRepository _professorRepository;

    public AtualizaCursoHandler(ICursoRepository cursoRepository, IProfessorRepository professorRepository)
    {
        _cursoRepository = cursoRepository;
        _professorRepository = professorRepository;
    }

    public async Task<AtualizaCursoResponse> AtualizarCursoAsync(int idCurso, CriaCursoRequest cursoRequest)
    {
        var curso = await _cursoRepository.ObtemCursoPorIdAsync(idCurso);
        var professor = await _professorRepository.ObtemProfessorPorIdAsync(cursoRequest.professorId);

        var cursoAtualizado = await _cursoRepository.AtualizarCursoAsync(curso, cursoRequest, professor);

        var duracao = $"O curso tem duração de {cursoAtualizado.DataInicio} até {cursoAtualizado.DataFim}";

        return new AtualizaCursoResponse(idCurso, cursoAtualizado.Nome, duracao, cursoAtualizado.Professor.Nome);
    }
}
