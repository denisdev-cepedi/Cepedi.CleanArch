using Cepedi.Domain.Entities;

namespace Cepedi.Domain.Repository;

public interface ICursoRepository 
{
    Task<CursoEntity> ObtemCursoPorIdAsync(int id);
    Task<IEnumerable<CursoEntity>> ObtemCursosAsync();
    Task<CursoEntity> CriaNovoCursoAsync(CursoEntity curso);
    Task<CursoEntity> AtualizaCursoAsync(CursoEntity curso);
    Task<CursoEntity> DeletaCursoAsync(int id);
}