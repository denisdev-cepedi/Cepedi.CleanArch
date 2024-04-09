using Cepedi.Shareable.Requests;

namespace Cepedi.Domain.Services;
public interface IAtualizaCursoHandler
{
    Task<int> AtualizaCursoAsync(AtualizaCursoRequest request);
}
