﻿using Cepedi.Shareable.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Cepedi.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CursoController : ControllerBase
{
    private readonly ILogger<CursoController> _logger;

    public CursoController(ILogger<CursoController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{idCurso}")]
    public async Task<ActionResult<ObtemCursoResponse>> ConsultarCursoAsync([FromRoute] int idCurso)
    {
        // Aqui eu utilizaria o service definido em cepedi.ioc, e tiraria a linha
        // return Ok();
        return Ok();
    }
}
