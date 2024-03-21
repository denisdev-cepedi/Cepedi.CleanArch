using Cepedi.Shareable;

namespace Cepedi.Domain;

public class DeletarCursoHandler : IDeletarCursoHandler
{
    private readonly ICursoRepository _cursoRepository;

    public DeletarCursoHandler(ICursoRepository cursoRepository)
    {
        _cursoRepository = cursoRepository;
    }

    public async Task<int> DeletarCursoAsync(int request)
    {
        var curso = await _cursoRepository.ObtemCursoPorIdAsync(request);
        if (curso == null)
        {
            throw new Exception("Curso não encontrado");
        }
        else
        {
            await _cursoRepository.DeletarCursoDbAsync(curso);
            return default(int);
        }
    }
}
