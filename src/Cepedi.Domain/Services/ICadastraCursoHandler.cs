
using Cepedi.Shareable.Requests;

namespace Cepedi.Domain.Services;

public interface ICadastraCursoHandler
{
    Task<int>CadastraCursoAsync(CadastraCursoRequest request);
}
