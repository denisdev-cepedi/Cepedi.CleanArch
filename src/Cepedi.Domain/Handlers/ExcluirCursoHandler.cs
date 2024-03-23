namespace Cepedi.Domain;

public class ExcluirCursoHandler : IExcluirCursoHandler
{
    private readonly ICursoRepository _cursoRepository;
    public ExcluirCursoHandler(ICursoRepository cursoRepository) => _cursoRepository = cursoRepository;
    public Task<int> ExcluirCursoAsync(int idCurso)
    {
        return _cursoRepository.ExcluirCursoAsync(idCurso);
    }
}