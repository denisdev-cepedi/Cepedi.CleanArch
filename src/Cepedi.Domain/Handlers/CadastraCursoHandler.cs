using Cepedi.Shareable.Requests;
using Cepedi.Domain.Entities;
using Cepedi.Domain.Services;
using Cepedi.Domain.Repository;

namespace Cepedi.Domain.Handlers;

public class CadastraCursoHandler : ICadastraCursoHandler   {
    private readonly ICursoRepository _cursoRepository;

    public CadastraCursoHandler(ICursoRepository cursoRepository){
        _cursoRepository = cursoRepository;
    }

    public async Task<int> CadastraCursoAsync(CadastraCursoRequest request){
        var curso = new CursoEntity{
            Nome = request.Nome,
            Descricao = request.Descricao,
            DataInicio = request.DataInicio,
            DataFim = request.DataFim,
            ProfessorId = request.ProfessorId
        };
        return await _cursoRepository.CadastraNovoCursoAsync(curso);
    }

}