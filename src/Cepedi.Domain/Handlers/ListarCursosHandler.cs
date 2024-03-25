using Cepedi.Domain.Services;
using Cepedi.Shareable.Responses;

namespace Cepedi.Domain;

public class ListarCursosHandler : IListarCursosHandler
{
    private readonly ICursoRepository _cursoRepository;

    public ListarCursosHandler(ICursoRepository cursoRepository)
    {
        _cursoRepository = cursoRepository;
    }

    public async Task<IEnumerable<ObtemCursoResponse>> ListarCursosAsync()
    {
        var cursos = await _cursoRepository.ListarCursosAsync();
        var listaReponse = new List<ObtemCursoResponse>();
        
        foreach (var curso in cursos)
        {
            var horario = $"O curso tem duração de {curso.DataInicio} até {curso.DataFim}";
            listaReponse.Add(new ObtemCursoResponse(curso.Nome, horario, curso.Professor.Nome));
        }

        return listaReponse;
    }
}
