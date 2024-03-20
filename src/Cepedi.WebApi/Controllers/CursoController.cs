﻿using Cepedi.Shareable.Responses;
using Cepedi.Shareable.Requests;
using Microsoft.AspNetCore.Mvc;
using Cepedi.Domain.Services;

namespace Cepedi.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CursoController : ControllerBase
{
    private readonly ILogger<CursoController> _logger;
    private readonly ICursoService _cursoService;

    public CursoController(ILogger<CursoController> logger, ICursoService cursoService)
    {
        _logger = logger;
        _cursoService = cursoService;
    }

    [HttpGet("{idCurso}")]
    public async Task<ActionResult<ObtemCursoResponse>> ConsultarCursoAsync([FromRoute] int idCurso)
    {
        var response = await _cursoService.GetById(idCurso);
        return Ok(response);        
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ObtemCursoResponse>>> ConsultarCursosAsync()
    {
        var response = await _cursoService.GetAll();
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<ObtemCursoResponse>> CriarCursoAsync([FromBody] CriaCursoRequest request)
    {
        var response = await _cursoService.Create(request);
        return Ok(response);
    }

    [HttpPut("{idCurso}")]
    public async Task<ActionResult<ObtemCursoResponse>> AtualizarCursoAsync([FromRoute] int idCurso, [FromBody] CriaCursoRequest request)
    {
        var response = await _cursoService.Update(idCurso, request);
        return Ok(response);
    }

    [HttpDelete("{idCurso}")]
    public async Task<ActionResult> DeletarCursoAsync([FromRoute] int idCurso)
    {
        await _cursoService.Delete(idCurso);
        return Ok();
    }
}
