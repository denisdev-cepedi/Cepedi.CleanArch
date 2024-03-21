using Cepedi.Data;
using Cepedi.Domain;
using Cepedi.Domain.Entities;
using Cepedi.Shareable;
using Cepedi.Shareable.Responses;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CursoController : ControllerBase
{
    private readonly ILogger<CursoController> _logger;
    private readonly IObtemCursoHandler _obtemCursoHandler;
    private readonly IInserirCursoHandler _inserirCursoHandler;
    private readonly IAtualizarCursoHandler _atualizarCursoHandler;
    private readonly IExcluirHandler _excluirCursoHandler;
    public CursoController(ILogger<CursoController> logger,
    IObtemCursoHandler obtemCursoHandler, IInserirCursoHandler inserirCursoHandler, IAtualizarCursoHandler atualizarCursoHandler, IExcluirHandler excluirCursoHandler)
    {
        _logger = logger;
        _obtemCursoHandler = obtemCursoHandler;
        _inserirCursoHandler = inserirCursoHandler;
        _atualizarCursoHandler = atualizarCursoHandler;
        _excluirCursoHandler = excluirCursoHandler;
    }

    [HttpGet("{idCurso}")]
    public async Task<ActionResult<ObtemCursoResponse>> ConsultarCursoAsync([FromRoute] int idCurso)
    {
        return Ok(await _obtemCursoHandler.ObterCursoAsync(idCurso));
    }

    [HttpPost]
    public async Task<ActionResult> InserirCursoAsync([FromBody] CursoDto cursoDto)
    {
        var curso = await _inserirCursoHandler.InserirCursoAsync(cursoDto);
        return Ok(curso);
    }

    [HttpPut("{idCurso}")]
    public async Task<ActionResult> AtualizarCursoAsync([FromRoute] int idCurso, [FromBody] CursoDto cursoDto)
    {
        var curso = await _atualizarCursoHandler.AtualizarCursoAsync(idCurso, cursoDto);
        return Ok(curso);
    }

    [HttpDelete("{idCurso}")]
    public async Task<ActionResult> ExcluirCursoAsync([FromRoute] int idCurso)
    {
        await _excluirCursoHandler.ExcluirAsync(idCurso);
        return Ok();
    }
}
