using Cepedi.Domain.Entities;
using Cepedi.Shareable.;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using MediatR;

namespace Cepedi.Domain.Handlers;

public class CriarCursoRequestHandler : IRequestHandler<CriaCursoRequest, CriaCursoResponse>
{
    private readonly ICursoRepository _cursoRepository;

    public CriarCursoRequestHandler(ICursoRepository cursoRepository)
    {
        _cursoRepository = cursoRepository;
    }

    public async Task<int> Handle(CriaCursoRequest request, CancellationToken cancellationToken)
    {
        var novoCurso = new CursoEntity
        {
            Nome = request.Nome,
            Descricao = request.Descricao,
            DataInicio = request.DataInicio,
            DataFim = request.DataFim,
            ProfessorId = request.ProfessorId,
        };

        await _cursoRepository.CriaNovoCursoAsync(novoCurso);

        return new CriaCursoResponse(novoCurso.Nome, novoCurso.Descricao);
    }
}
