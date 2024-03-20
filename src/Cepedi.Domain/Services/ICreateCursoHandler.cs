using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;

namespace Cepedi.Domain;

public interface ICreateCursoHandler
{
    Task<ObtemCursoResponse> CreateCursoAsync(CriaCursoRequest criaCursoRequest);
}
