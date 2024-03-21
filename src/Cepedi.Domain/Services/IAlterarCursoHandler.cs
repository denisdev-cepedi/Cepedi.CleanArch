using Cepedi.Shareable;

namespace Cepedi.Domain;

public interface IAlterarCursoHandler
{
    Task<int>  AlterarCursoAsync(AlterarCursoRequest request);
}
