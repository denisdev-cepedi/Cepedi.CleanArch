using Cepedi.Domain.Entities;
using Cepedi.Shareable;

namespace Cepedi.Domain;

public interface IAtualizarCursoHandler
{
    public Task<CursoEntity> AtualizarCursoAsync(int idCurso, CursoDto cursoDto);
}
