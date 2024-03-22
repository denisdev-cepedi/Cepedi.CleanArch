using Cepedi.Domain.Entities;
using Cepedi.Shareable.Requests;

namespace Cepedi.Domain;

public interface ICriarCursoHandler
{
    Task<CursoEntity> CriarCursoAsync(CriarCursoRequest request);
}
