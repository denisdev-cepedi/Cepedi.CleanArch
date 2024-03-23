using Cepedi.Shareable.Responses;
using Cepedi.Shareable.Requests;
using Microsoft.AspNetCore.Mvc;
using Cepedi.Domain.Services;

namespace Cepedi.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CursoController : ControllerBase
{
    private readonly ILogger<CursoController> _logger;
    private readonly ICriaCursoHandler _criaCursoHandler;
    private readonly IObtemCursoHandler _obtemCursoHandler;
    private readonly IAtualizaCursoHandler _atualizaCursoHandler;
    private readonly IDeletaCursoHandler _deletaCursoHandler;

    public CursoController(
        ILogger<CursoController> logger, 
        ICriaCursoHandler criaCursoHandler, 
        IObtemCursoHandler obtemCursoHandler, 
        IAtualizaCursoHandler atualizaCursoHandler, 
        IDeletaCursoHandler deletaCursoHandler)
    {
        _logger = logger;
        _criaCursoHandler = criaCursoHandler;
        _obtemCursoHandler = obtemCursoHandler;
        _atualizaCursoHandler = atualizaCursoHandler;
        _deletaCursoHandler = deletaCursoHandler;
    }

    [HttpGet("{idCurso}")]
    public async Task<ActionResult<ObtemCursoResponse>> ConsultarCursoAsync([FromRoute] int idCurso)
    {
        var response = await _obtemCursoHandler.ObtemCursoAsync(idCurso);
        return Ok(response);        
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ObtemCursoResponse>>> ConsultarCursosAsync()
    {
        var response = await _obtemCursoHandler.ObtemCursosAsync();
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<int>> CriarCursoAsync([FromBody] CriaCursoRequest request)
    {
        var response = await _criaCursoHandler.CriaCursoAsync(request);
        return Ok(response);
    }

    [HttpPut("{idCurso}")]
    public async Task<ActionResult<int>> AtualizarCursoAsync([FromBody] AtualizaCursoRequest request)
    {
        var response = await _atualizaCursoHandler.AtualizaCursoAsync(request);
        return Ok(response);
    }

    [HttpDelete("{idCurso}")]
    public async Task<ActionResult<int>> DeletarCursoAsync([FromRoute] int idCurso)
    {
        var response = await _deletaCursoHandler.DeletaCursoAsync(idCurso);
        return Ok(response);
    }
}
