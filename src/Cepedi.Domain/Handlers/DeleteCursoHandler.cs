using Cepedi.Domain.Services;
using Cepedi.Shareable.Exceptions;

namespace Cepedi.Domain;

public class DeleteCursoHandler : IDeleteCursoHandler
{
    private readonly ICursoRepository _cursoRepository;
    private readonly IProfessorRepository _professorRepository;

    public DeleteCursoHandler(ICursoRepository cursoRepository, IProfessorRepository professorRepository)
    {
        _cursoRepository = cursoRepository;
        _professorRepository = professorRepository;
    }

    public async Task DeleteCursoAsync(int idCurso)
    {
        var curso = await _cursoRepository.ObtemCursoPorIdAsync(idCurso);

        if (curso == null) throw new CursoNaoEncontradoException(idCurso);

        await _cursoRepository.ExcluirCursoAsync(curso);
    }
}
