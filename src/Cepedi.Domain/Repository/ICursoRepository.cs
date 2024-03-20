using Cepedi.Domain.Entities;
using Cepedi.Shareable.Responses;

namespace Cepedi.Domain;


public interface ICursoRepository
{
    Task<IEnumerable<CursoEntity>> ObterTodosCursosAsync();
    Task<CursoEntity> ObtemCursoPorIdAsync(int idCurso);
    Task AdicionarCursoAsync(CursoEntity curso);
    Task AtualizarCursoAsync(CursoEntity curso);
    Task RemoverCursoAsync(int idCurso);
}
