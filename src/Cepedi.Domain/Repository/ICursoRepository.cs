using Cepedi.Domain.Entities;
using Cepedi.Shareable;

namespace Cepedi.Domain;

public interface ICursoRepository
{
    Task<CursoEntity> ObtemCursoPorIdAsync(int idCurso);
    Task<int> AddCursoDbAsync(CursoEntity entity);
    Task<CursoEntity> AlterarCursoDbAsync(CursoEntity entity);
    Task<CursoEntity> DeletarCursoDbAsync(CursoEntity entity);
}
