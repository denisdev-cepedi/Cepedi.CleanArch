using Cepedi.Domain.Entities;
using Cepedi.Shareable.Requests;

namespace Cepedi.Domain;

public interface ICursoRepository
{
    Task<CursoEntity> ObtemCursoPorIdAsync(int idCurso);
    Task<List<CursoEntity>> ObtemCursosAsync();
    Task<int> CriaNovoCursoAsync(CursoEntity curso);
    Task<int> AlterarCursoAsync(CursoEntity curso);
    Task<int> ExcluirCursoAsync(int idCurso);
}
