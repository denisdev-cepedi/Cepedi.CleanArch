using Cepedi.Domain.Entities;
using Cepedi.Domain.Repository;
using Cepedi.Domain.Services;
using Cepedi.Shareable.Requests;

namespace Cepedi.Domain.Handlers;

public class CriaCursoHandler : ICriaCursoHandler
{
    private readonly ICursoRepository _cursoRepository;

    public CriaCursoHandler(ICursoRepository cursoRepository)
    {
        _cursoRepository = cursoRepository;
    }

    public async Task<int> CriaCursoAsync(CriaCursoRequest request)
    {
        var curso = new CursoEntity
        {
            Nome = request.Nome,
            Descricao = request.Descricao,
            DataInicio = request.DataInicio,
            DataFim = request.DataFim,
            ProfessorId = request.ProfessorId
        };

        return await _cursoRepository.CriaNovoCursoAsync(curso);
    }

}
