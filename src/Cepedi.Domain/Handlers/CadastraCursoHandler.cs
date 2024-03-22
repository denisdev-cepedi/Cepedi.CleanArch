using Cepedi.Domain.Entities;
using Cepedi.Domain.Repository;
using Cepedi.Domain.Services;
using Cepedi.Shareable;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;

namespace Cepedi.Domain.Handlers;

public class CadastraCursoHandler : ICadastraCursoHandler
{
    private readonly ICursoRepository _cursoRepository;

    public CadastraCursoHandler(ICursoRepository cursoRepository)
    {
        _cursoRepository = cursoRepository;
    }

    public async Task<CadastraCursoResponse> CadastraCursoAsync(CadastraCursoRequest curso)
    {
        var _curso = await _cursoRepository.CadastraCursoAsync(curso);

        return new CadastraCursoResponse(_curso.Id);
    }
}