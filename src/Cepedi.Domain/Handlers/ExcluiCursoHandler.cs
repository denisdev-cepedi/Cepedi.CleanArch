using Cepedi.Domain.Services;
using Cepedi.Domain.Repository;

namespace Cepedi.Domain.Handlers;
public class ExcluiCursoHandler : IExcluiCursoHandler
{
    private readonly ICursoRepository _cursoRepository;
    public ExcluiCursoHandler(ICursoRepository cursoRepository) => _cursoRepository = cursoRepository;
    public Task<int> ExcluiCursoAsync(int idCurso){
        return _cursoRepository.ExcluiCursoAsync(idCurso);
    }
}
