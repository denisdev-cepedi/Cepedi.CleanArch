using Cepedi.Domain.Entities;
using Cepedi.Shareable;

namespace Cepedi.Domain;

public class AtualizarCursoHandler : IAtualizarCursoHandler
{
    private readonly ICursoRepository _cursoRepository;

    public AtualizarCursoHandler(ICursoRepository cursoRepository)
    {
        _cursoRepository = cursoRepository;
    }
    public async Task<CursoEntity> AtualizarCursoAsync(int idCurso, CursoDto cursoDto)
    {
        return await _cursoRepository.AtualizarCursoAsync(idCurso, cursoDto);
    }
}
