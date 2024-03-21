using Cepedi.Shareable;

namespace Cepedi.Domain;

public interface ICriarCursoHandler
{
    Task<int> CriarCursoAsync(CriarCursoRequest request);
}
