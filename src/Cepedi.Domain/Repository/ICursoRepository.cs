using Cepedi.Domain.Entities;

namespace Cepedi.Domain.Repository;

public interface ICursoRepository 
{
    Task<CursoEntity> ObtemCursoPorIdAsync(int id);
    Task<IEnumerable<CursoEntity>> ObtemCursosAsync();
    Task<int> CriaNovoCursoAsync(CursoEntity curso);
    Task<int> AtualizaCursoAsync(CursoEntity curso);
    Task<int> DeletaCursoAsync(int id);
}