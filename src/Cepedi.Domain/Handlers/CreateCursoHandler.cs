using Cepedi.Domain.Entities;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;

namespace Cepedi.Domain;

public class CreateCursoHandler : ICreateCursoHandler
{
    private readonly ICursoRepository _cursoRepository;
    private readonly IProfessorRepository _professorRepository;

    public CreateCursoHandler(ICursoRepository cursoRepository, IProfessorRepository professorRepository)
    {
        _cursoRepository = cursoRepository;
        _professorRepository = professorRepository;
    }

    public async Task<ObtemCursoResponse> CreateCursoAsync(CriaCursoRequest criaCursoRequest)
    {
        var professor = await _professorRepository.ObtemProfessorPorIdAsync(criaCursoRequest.professorId);

        var curso = new CursoEntity
        {
            Nome = criaCursoRequest.nome,
            Descricao = criaCursoRequest.descricao,
            DataInicio = criaCursoRequest.inicio,
            DataFim = criaCursoRequest.fim,
            Professor = professor
        };

        var cursoCriado = await _cursoRepository.CriaCursoAsync(curso);
        var duracao = $"O curso tem duração de {curso.DataInicio} até {curso.DataFim}";

        return new ObtemCursoResponse(curso.Nome, duracao, professor.Nome);
    }
}
