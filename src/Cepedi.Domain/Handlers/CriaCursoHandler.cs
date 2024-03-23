using Cepedi.Domain.Entities;
using Cepedi.Domain.Repository;
using Cepedi.Domain.Services;
using Cepedi.Shareable.Requests;

namespace Cepedi.Domain.Handlers;

public class CriaCursoHandler : ICriaCursoHandler
{
    private readonly ICursoRepository _cursoRepository;
    private readonly IProfessorRepository _professorRepository;

    public CriaCursoHandler(ICursoRepository cursoRepository, IProfessorRepository professorRepository)
    {
        _cursoRepository = cursoRepository;
        _professorRepository = professorRepository;
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

        _ = await _professorRepository.ObtemProfessorPorIdAsync(curso.ProfessorId) ?? throw new KeyNotFoundException("Professor não encontrado");

        return await _cursoRepository.CriaNovoCursoAsync(curso);
    }

}
