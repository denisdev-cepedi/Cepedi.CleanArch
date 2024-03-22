using Cepedi.Shareable.Requests;
using Cepedi.Domain.Entities;
using Cepedi.Domain.Services;
using Cepedi.Domain.Repository;

namespace Cepedi.Domain.Handlers;
public class AtualizaCursoHandler : IAtualizaCursoHandler
{
    public readonly ICursoRepository _cursoRepository;
    public AtualizaCursoHandler(ICursoRepository cursoRepository) => _cursoRepository = cursoRepository;
    public async Task<int> AtualizaCursoAsync(AtualizaCursoRequest request)
    {
        var curso = await _cursoRepository.ObtemCursoPorIdAsync(request.idCurso);
        if (curso == null)
        {
            return 0;
        }
        curso.Nome = request.Nome;
        curso.Descricao = request.Descricao;
        curso.DataFim = request.DataFim;
        curso.DataInicio = request.DataInicio;
        curso.ProfessorId = request.ProfessorId;
        return await _cursoRepository.AtualizaCursoAsync(curso);
    }
}
