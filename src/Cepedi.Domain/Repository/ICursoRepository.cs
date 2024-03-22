using Cepedi.Domain.Entities;

namespace Cepedi.Domain;

public interface ICursoRepository
{
    Task<CursoEntity> ObtemCursoPorIdAsync(int idCurso);
    Task<CursoEntity> CriarCursoAsync(CursoEntity curso);
    Task<IEnumerable<CursoEntity>> ObtemCursosAsync();
    Task<int> AlterarCursoAsync(CursoEntity curso);
    Task<int> ExcluirCursoAsync(int idCurso);
}
