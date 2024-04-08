using Cepedi.Domain.Entities;
using Cepedi.Shareable;
using Cepedi.Shareable.Responses;
using MediatR;

namespace Cepedi.Domain;

public class CriarCursoHandlder : IRequestHandler<CriarCursoRequest, CriarCursoResponse>
{
    private readonly ICursoRepository _cursoRepository;
    private readonly IProfessorRepository _professorRepository;

    public CriarCursoHandlder(ICursoRepository cursoRepository, IProfessorRepository professorRepository)
    {
        _cursoRepository = cursoRepository;
        _professorRepository = professorRepository;
    }

    public async Task<CriarCursoResponse> Handle(CriarCursoRequest request, CancellationToken cancellationToken)
    {
        ProfessorEntity professor = _professorRepository.ObtemProfessorPorIdAsync(request.idProfessor);
        var novoCurso = new CursoEntity
        {

            Nome = request.nome,
            Descricao = request.descricao,
            DataInicio = request.inicio,
            DataFim = request.fim,
            Professor = professor,
        };

        await _cursoRepository.AddCursoDbAsync(novoCurso);
        return new CriarCursoResponse(novoCurso.Id, novoCurso.Nome);
    }
}
