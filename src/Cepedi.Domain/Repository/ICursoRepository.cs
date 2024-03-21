using Cepedi.Domain.Entities;
using Cepedi.Shareable.Requests;

namespace Cepedi.Domain.Repository;

public interface ICursoRepository
{
    Task<CursoEntity> ObtemCursoPorIdAsync(int idCurso);
    Task<IEnumerable<CursoEntity>> ObtemTodosCursosAsync();
    Task<CursoEntity> CadastraCursoAsync(CadastraCursoRequest request);
    Task<CursoEntity> EditaCursoAsync(int cursoId, EditaCursoRequest request);
    Task<int> DeletaCursoAsync(int cursoId);
}
