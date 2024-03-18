using Cepedi.Shareable.Responses;

namespace Cepedi.Data.Services;

public interface ICursoService{
    public Task<ObtemCursoResponse> GetById(int id, CancellationToken cancellationToken = default);
}