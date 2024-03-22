using Cepedi.Domain;
using Cepedi.Shareable.Responses;
using Cepedi.Shareable.Requests;
using Cepedi.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cepedi.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CursoController : ControllerBase
{
    private readonly ILogger<CursoController> _logger;
    private readonly IObtemCursoHandler _obtemCursoHandler;
    private readonly ICadastraCursoHandler _cadastraCursoHandler;
    private readonly IAtualizaCursoHandler _atualizaCursoHandler;
    private readonly IExcluiCursoHandler _excluiCursoHandler;
    public CursoController(
        ILogger<CursoController> logger,
        IObtemCursoHandler obtemCursoHandler,
        ICadastraCursoHandler cadastraCursoHandler,
        IAtualizaCursoHandler atualizaCursoHandler,
        IExcluiCursoHandler excluiCursoHandler)
    {
        _logger = logger;
        _obtemCursoHandler = obtemCursoHandler;
        _cadastraCursoHandler = cadastraCursoHandler;
        _atualizaCursoHandler = atualizaCursoHandler;
        _excluiCursoHandler = excluiCursoHandler;
    }
    [HttpGet("{idCurso}")]
    public async Task<ActionResult<ObtemCursoResponse>> ConsultarCursoAsync([FromRoute] int idCurso)
    {
        return Ok(await _obtemCursoHandler.ObterCursoAsync(idCurso));
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ObtemCursoResponse>>> ConsultarCursosAsync(){
        return Ok(await _obtemCursoHandler.ObterCursosAsync());
    }
    [HttpPost]
    public async Task<ActionResult<int>> CadastraCursoAsync([FromBody] CadastraCursoRequest request)
    {
        var cursoId = await _cadastraCursoHandler.CadastraCursoAsync(request);
        return Ok(cursoId);
    }

    [HttpPut]
    public async Task<ActionResult<int>> AtualizaCursoAsync([FromBody] AtualizaCursoRequest request){
        var cursoId = await _atualizaCursoHandler.AtualizaCursoAsync(request);
        return Ok(cursoId);
    }

    [HttpDelete("{idCurso}")]
    public async Task<ActionResult<int>> ExcluiCursoAsync([FromRoute] int idCurso){
        var cursoId = await _excluiCursoHandler.ExcluiCursoAsync(idCurso);
        return Ok(cursoId);
    }
}
