using Cepedi.IoC;
using Cepedi.IoC.services;
using Cepedi.Shareable.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Cepedi.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CursoController : ControllerBase
{
    private readonly ILogger<CursoController> _logger;
    private readonly CursoServiceCollection _service;

    public CursoController(ILogger<CursoController> logger, CursoServiceCollection service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet("{idCurso}")]
    public async Task<ActionResult<ObtemCursoResponse>> ConsultarCursoAsync([FromRoute] int idCurso)
    {
        return Ok(_service.GetByID(idCurso));
    }
}
