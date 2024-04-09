using Cepedi.Domain.Entities;

namespace Cepedi.Domain.Repository;

public interface ICursoRepository
{
    Task<CursoEntity> ObtemCursoPorIdAsync(int idCurso);
    Task<List<CursoEntity>> ObtemCursosAsync();
    Task<int> CadastraNovoCursoAsync(CursoEntity curso);
    Task<int> AtualizaCursoAsync(CursoEntity curso);
    Task<int> ExcluiCursoAsync(int idCurso);
}
