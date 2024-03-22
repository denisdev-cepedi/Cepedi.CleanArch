using Cepedi.Shareable.Responses;

namespace Cepedi.Domain.Services;

public interface IDeletaCursoHandler
{
    Task<DeletaCursoResponse> DeletaCursoAsync(int cursoId);
}