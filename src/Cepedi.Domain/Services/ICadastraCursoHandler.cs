using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;

namespace Cepedi.Domain.Services;

public interface ICadastraCursoHandler
{
    Task<CadastraCursoResponse> CadastraCursoAsync(CadastraCursoRequest curso);
}
