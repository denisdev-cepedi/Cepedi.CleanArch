using Cepedi.Data;
using Cepedi.Domain;
using Cepedi.Domain.Services;
using Cepedi.Shareable.Exceptions;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CursoController : ControllerBase
{
    private readonly ILogger<CursoController> _logger;
    private readonly IObtemCursoHandler _obtemCursoHandler;
    private readonly ICreateCursoHandler _createCursoHandler;
    private readonly IAtualizaCursoHandler _atualizaCursoHandler;
    private readonly IDeleteCursoHandler _deleteCursoHandler;
    private readonly ApplicationDbContext _context;
    public CursoController(ILogger<CursoController> logger,
    IObtemCursoHandler obtemCursoHandler,
    ICreateCursoHandler createCursoHandler,
    IAtualizaCursoHandler atualizaCursoHandler,
    IDeleteCursoHandler deleteCursoHandler)
    {
        _logger = logger;
        _obtemCursoHandler = obtemCursoHandler;
        _createCursoHandler = createCursoHandler;
        _atualizaCursoHandler = atualizaCursoHandler;
        _deleteCursoHandler = deleteCursoHandler;
    }

    [HttpGet("{idCurso}")]
    public async Task<ActionResult<ObtemCursoResponse>> ConsultarCursoAsync([FromRoute] int idCurso)
    {
        return Ok(await _obtemCursoHandler.ObterCursoAsync(idCurso));
    }

    [HttpPost]
    public async Task<ActionResult<ObtemCursoResponse>> CriaCursoAsync([FromBody] CriaCursoRequest criaCursoRequest)
    {
        return Ok(await _createCursoHandler.CreateCursoAsync(criaCursoRequest));
    }

    [HttpPut("{idCurso}")]
    public async Task<ActionResult<AtualizaCursoResponse>> AtualizarCursoAsync([FromRoute] int idCurso, [FromBody] CriaCursoRequest criaCursoRequest)
    {
        return Ok(await _atualizaCursoHandler.AtualizarCursoAsync(idCurso, criaCursoRequest));
    }

    [HttpDelete("{idCurso}")]
    public async Task<IActionResult> DeleteCursoAsync([FromRoute] int idCurso)
    {
        try
        {
            await _deleteCursoHandler.DeleteCursoAsync(idCurso);
            return Ok();
        }
        catch (CursoNaoEncontradoException)
        {
            return NotFound();
        }
    }
}
