using Cepedi.Shareable.Responses;
using Cepedi.Shareable.Requests;

namespace Cepedi.Domain.Services;

public interface ICursoService{
    public Task<ObtemCursoResponse> GetById(int id, CancellationToken cancellationToken = default);
    public Task<IEnumerable<ObtemCursoResponse>> GetAll(CancellationToken cancellationToken = default);
    public Task<ObtemCursoResponse> Create(CriaCursoRequest request, CancellationToken cancellationToken = default);
}