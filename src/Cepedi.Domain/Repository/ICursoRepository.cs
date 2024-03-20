using Cepedi.Domain.Entities;
using Cepedi.Shareable;

namespace Cepedi.Domain;

public interface ICursoRepository
{
    Task<CursoEntity> ObtemCursoPorIdAsync(int idCurso);
    Task<CursoEntity> InserirCursoAsync(CursoDto cursoDto);
}
