using Cepedi.Domain.Entities;

namespace Cepedi.Domain;

public interface ICursoRepository
{
    Task<CursoEntity> ObtemCursoPorIdAsync(int idCurso);
    Task<CursoEntity> CriaCursoAsync(CursoEntity curso);
}
