using Cepedi.Domain.Entities;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using MediatR;

namespace Cepedi.Domain;

public class CreateCursoHandler : IRequestHandler<CriaCursoRequest, CriaCursoResponse>
{
    private readonly ICursoRepository _cursoRepository;
    private readonly IProfessorRepository _professorRepository;

    public CreateCursoHandler(ICursoRepository cursoRepository, IProfessorRepository professorRepository)
    {
        _cursoRepository = cursoRepository;
        _professorRepository = professorRepository;
    }

    // public async Task<ObtemCursoResponse> CreateCursoAsync(CriaCursoRequest criaCursoRequest)
    // {
    //     var professor = await _professorRepository.ObtemProfessorPorIdAsync(criaCursoRequest.ProfessorId);

    //     var curso = new CursoEntity
    //     {
    //         Nome = criaCursoRequest.Nome,
    //         Descricao = criaCursoRequest.Descricao,
    //         DataInicio = criaCursoRequest.Inicio,
    //         DataFim = criaCursoRequest.Fim,
    //         Professor = professor
    //     };

    //     var cursoCriado = await _cursoRepository.CriaCursoAsync(curso);
    //     var duracao = $"O curso tem duração de {cursoCriado.DataInicio} até {cursoCriado.DataFim}";

    //     return new ObtemCursoResponse(cursoCriado.Nome, duracao, professor.Nome);
    // }

    public async Task<CriaCursoResponse> Handle(CriaCursoRequest criaCursoRequest, CancellationToken cancellationToken)
    {
        var professor = await _professorRepository.ObtemProfessorPorIdAsync(criaCursoRequest.ProfessorId);

        var curso = new CursoEntity
        {
            Nome = criaCursoRequest.Nome,
            Descricao = criaCursoRequest.Descricao,
            DataInicio = criaCursoRequest.Inicio,
            DataFim = criaCursoRequest.Fim,
            Professor = professor
        };

        return new CriaCursoResponse(curso.Id, curso.Nome);
    }
}
