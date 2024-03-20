using Cepedi.Domain;
using Cepedi.Domain.Services;
using Cepedi.Shareable;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Cepedi.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CursoController : ControllerBase
{
    private readonly ILogger<CursoController> _logger;
    private readonly IObtemCursoHandler _obtemCursoHandler;
    private readonly ICadastraCursoHandler _cadastraCursoHandler;
    private readonly IEditaCursoHandler _editaCursoHandler;
    private readonly IDeletaCursoHandler _deletaCursoHandler;

    public CursoController(
        ILogger<CursoController> logger,
        IObtemCursoHandler obtemCursoHandler,
        ICadastraCursoHandler cadastraCursoHandler,
        IEditaCursoHandler editaCursoHandler,
        IDeletaCursoHandler deletaCursoHandler
    )
    {
        _logger = logger;
        _obtemCursoHandler = obtemCursoHandler;
        _cadastraCursoHandler = cadastraCursoHandler;
        _editaCursoHandler = editaCursoHandler;
        _deletaCursoHandler = deletaCursoHandler;
    }

    [HttpGet("{idCurso}")]
    public async Task<ActionResult<ObtemCursoResponse>> ConsultarCursoAsync([FromRoute] int idCurso)
    {
        return Ok(await _obtemCursoHandler.ObterCursoAsync(idCurso));
    }

    [HttpPost]
    public async Task<ActionResult<ObtemCursoResponse>> CadastrarCursoAsync([FromBody] CadastraCursoRequest curso)
    {
        return Ok(await _cadastraCursoHandler.CadastraCursoAsync(curso));
    }

    [HttpPut("{cursoId}")]
    public async Task<ActionResult<EditaCursoResponse>> EditarCursoAsync([FromRoute] int cursoId, [FromBody] EditaCursoRequest curso)
    {
        return Ok(await _editaCursoHandler.EditaCursoAsync(cursoId, curso));
    }
    [HttpDelete("{cursoId}")]
    public async Task<ActionResult<ObtemCursoResponse>> DeletarCursoAsync([FromRoute] int cursoId)
    {
        return Ok(await _deletaCursoHandler.DeletaCursoAsync(cursoId));
    }
}
