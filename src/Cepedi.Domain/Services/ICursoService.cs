using Cepedi.Shareable.Responses;
using Cepedi.Shareable.Requests;
using Cepedi.Domain.Entities;

namespace Cepedi.Domain.Services;

public interface ICursoService{
    public Task<ObtemCursoResponse> GetById(int id, CancellationToken cancellationToken = default);
    public Task<IEnumerable<ObtemCursoResponse>> GetAll(CancellationToken cancellationToken = default);
    public Task<CursoEntity> Create(CriaCursoRequest request, CancellationToken cancellationToken = default);
    public Task<ObtemCursoResponse> Update(int id, CriaCursoRequest request, CancellationToken cancellationToken = default);
    public Task Delete(int id, CancellationToken cancellationToken = default);
}