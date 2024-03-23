using Cepedi.Domain.Repository;
using Cepedi.Domain.Services;
using Cepedi.Shareable.Requests;

namespace Cepedi.Domain.Handlers;

public class AtualizaCursoHandler : IAtualizaCursoHandler
{
    private readonly ICursoRepository _cursoRepository;
    private readonly IProfessorRepository _professorRepository;

    public AtualizaCursoHandler(ICursoRepository cursoRepository, IProfessorRepository professorRepository)
    {
        _cursoRepository = cursoRepository;
        _professorRepository = professorRepository;
    }

    public async Task<int> AtualizaCursoAsync(AtualizaCursoRequest request)
    {
        var curso = await _cursoRepository.ObtemCursoPorIdAsync(request.IdCurso);

        var professor = await _professorRepository.ObtemProfessorPorIdAsync(request.ProfessorId);

        if (professor == null)
        {
            throw new KeyNotFoundException($"Professor com id {request.ProfessorId} não.");
        }

        curso.Nome = request.Nome;
        curso.Descricao = request.Descricao;
        curso.DataInicio = request.DataInicio;
        curso.DataFim = request.DataFim;
        curso.ProfessorId = request.ProfessorId;

        return await _cursoRepository.AtualizaCursoAsync(curso);
    }

}
