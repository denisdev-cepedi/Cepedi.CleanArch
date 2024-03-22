using Cepedi.Domain.Entities;
using Cepedi.Shareable.Requests;

namespace Cepedi.Domain;

public class CriarCursoHandler : ICriarCursoHandler
{
    private readonly ICursoRepository _cursoRepository;
    public CriarCursoHandler(ICursoRepository cursoRepository)
    {
        _cursoRepository = cursoRepository;
    }
    public async Task<CursoEntity> CriarCursoAsync(CriarCursoRequest request)
    {
        var novoCurso = new CursoEntity{
            Nome = request.Nome,
            Descricao = request.Descricao,
            DataInicio = request.DataInicio,
            DataFim = request.DataFim,
            ProfessorId = request.ProfessorId
        };
         return await _cursoRepository.CriarCursoAsync(novoCurso);
        // var idCurso = await _cursoRepository.CriarCursoAsync(novoCurso);
        // return (T)Activator.CreateInstance(typeof(T), idCurso);
    }
}
