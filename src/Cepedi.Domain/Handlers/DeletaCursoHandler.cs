using Cepedi.Domain.Repository;
using Cepedi.Domain.Services;

namespace Cepedi.Domain.Handlers;

public class DeletaCursoHandler : IDeletaCursoHandler
{
    private readonly ICursoRepository _cursoRepository;

    public DeletaCursoHandler(ICursoRepository cursoRepository)
    {
        _cursoRepository = cursoRepository;
    }

    public async Task<int> DeletaCursoAsync(int id)
    {
        return await _cursoRepository.DeletaCursoAsync(id);
    }

}
