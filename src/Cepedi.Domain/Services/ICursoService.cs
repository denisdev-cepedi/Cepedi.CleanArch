using Cepedi.Shareable.Responses;

namespace Cepedi.Domain.Services;

public interface ICursoService{
    public Task<ObtemCursoResponse> GetById(int id, CancellationToken cancellationToken = default);
    public Task<IEnumerable<ObtemCursoResponse>> GetAll(CancellationToken cancellationToken = default);
}