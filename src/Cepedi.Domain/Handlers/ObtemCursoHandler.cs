using Cepedi.Domain.Interfaces;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using MediatR;

namespace Cepedi.Domain.Handlers;
public class ObtemCursoHandler : IRequestHandler<ObtemCursoRequest, ObtemCursoResponse>
{
    private readonly ICursoRepository _cursoRepository;
    private readonly IProfessorRepository _professorRepository;

    public ObtemCursoHandler(ICursoRepository cursoRepository, IProfessorRepository professorRepository)
    {
        _cursoRepository = cursoRepository;
        _professorRepository = professorRepository;
    }

    public async Task<ObtemCursoResponse> Handle(ObtemCursoRequest request, CancellationToken cancellationToken)
    {
        var curso = _cursoRepository.GetById(request.idCurso);

        if(curso != null)
            curso.Professor = _professorRepository.GetById(curso.ProfessorId);

        var msg = $"de {curso.DataInicio.ToString("dd/MM/yyyy")} até {curso.DataFim.ToString("dd/MM/yyyy")}";

        return new ObtemCursoResponse(curso.Nome, msg, curso.Professor.Nome);
    }
}
