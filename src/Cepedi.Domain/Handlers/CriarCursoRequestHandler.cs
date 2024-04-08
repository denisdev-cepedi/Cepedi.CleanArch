using Cepedi.Domain.Entities;
using Cepedi.Domain.Repository;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using MediatR;

namespace Cepedi.Domain.Handlers;


public class CriarCursoRequestHandler : IRequestHandler<CriarCursoRequest, CriarCursoResponse>
{
    private readonly ICursoRepository _cursoRepository;

    public CriarCursoRequestHandler(ICursoRepository cursoRepository)
    {
        _cursoRepository = cursoRepository;
    }

    public async Task<CriarCursoResponse> Handle(CriarCursoRequest request, CancellationToken cancellationToken)
    {
        var curso = new CursoEntity()
        {
            Nome = request.Nome, 
            Descricao = request.Descricao, 
            DataInicio = request.DataInicio,
            DataFim = request.DataFim,
            ProfessorId = request.ProfessorId
        };

        await _cursoRepository.CriaNovoCursoAsync(curso);

        return new CriarCursoResponse(curso.Id, curso.Nome);
    }
}
