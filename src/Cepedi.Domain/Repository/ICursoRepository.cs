using Cepedi.Domain.Entities;
using Cepedi.Shareable.Requests;

namespace Cepedi.Domain;

public interface ICursoRepository
{
    Task<CursoEntity> ObtemCursoPorIdAsync(int idCurso);
    Task<CursoEntity> CriaCursoAsync(CursoEntity curso);
    Task<CursoEntity> AtualizarCursoAsync(CursoEntity curso, CriaCursoRequest cursoRequest, ProfessorEntity professor);
}
