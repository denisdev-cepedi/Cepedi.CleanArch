using Cepedi.Domain.Entities;
using Cepedi.Shareable;

namespace Cepedi.Domain;

public interface IInserirCursoHandler
{
    public Task<CursoEntity> InserirCursoAsync(CursoDto cursoDto);
}
