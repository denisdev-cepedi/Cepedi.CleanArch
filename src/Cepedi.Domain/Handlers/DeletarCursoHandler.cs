using Cepedi.Domain.Repository;

namespace Cepedi.Domain;

public class DeletarCursoHandler : IDeletarCursoHandler
{
    private readonly ICursoRepository _cursoRepository;
    public DeletarCursoHandler(ICursoRepository cursoRepository)
    {
        _cursoRepository = cursoRepository;
    }

    public async Task<int> DeletarCursoAsync(int idCurso)
    {
        var curso = await _cursoRepository.ObtemCursoPorIdAsync(idCurso);
        return await _cursoRepository.DeletarCursoAsync(curso);

    }
}
