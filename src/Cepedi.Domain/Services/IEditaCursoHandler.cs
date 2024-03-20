using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;

namespace Cepedi.Domain.Services;

public interface IEditaCursoHandler
{
    Task<EditaCursoResponse> EditaCursoAsync(int cursoId, EditaCursoRequest request);
}
