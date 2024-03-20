using Cepedi.Domain.Repository;
using Cepedi.Domain.Services;
using Cepedi.Shareable.Responses;

namespace Cepedi.Domain.Handlers;

public class DeletaCursoHandler : IDeletaCursoHandler
{
    private readonly ICursoRepository _cursoRepository;

    public DeletaCursoHandler(ICursoRepository cursoRepository)
    {
        _cursoRepository = cursoRepository;
    }

    public async Task<DeletaCursoResponse> DeletaCursoAsync(int cursoId)
    {
        await _cursoRepository.DeletaCursoAsync(cursoId);

        return new DeletaCursoResponse();
    }
}
