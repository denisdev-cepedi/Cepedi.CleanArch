using Cepedi.Shareable.Requests;

namespace Cepedi.Domain.Services;

public interface ICriaCursoHandler
{
    Task<int> CriaCursoAsync(CriaCursoRequest request);
}
