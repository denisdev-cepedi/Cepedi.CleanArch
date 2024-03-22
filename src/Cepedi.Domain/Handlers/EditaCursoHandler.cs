using Cepedi.Domain.Repository;
using Cepedi.Domain.Services;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;

namespace Cepedi.Domain.Handlers;

public class EditaCursoHandler : IEditaCursoHandler
{
    private readonly ICursoRepository _cursoRepository;
    private readonly IProfessorRepository _professorRepository;

    public EditaCursoHandler(ICursoRepository cursoRepository, IProfessorRepository professorRepository)
    {
        _cursoRepository = cursoRepository;
        _professorRepository = professorRepository;
    }

    public async Task<EditaCursoResponse> EditaCursoAsync(int cursoId, EditaCursoRequest curso)
    {
        var _curso = await _cursoRepository.EditaCursoAsync(cursoId, curso);
        var _professor = await _professorRepository.ObtemProfessorPorIdAsync(_curso.ProfessorId);
        var duracao = $"O curso tem duração de {_curso.DataInicio} até {_curso.DataFim}";

        return new EditaCursoResponse(_curso.Nome, duracao, _professor.Nome);
    }
}