using Cepedi.IoC.Services.Interfaces;
using Cepedi.Shareable.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Cepedi.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CursoController : ControllerBase
{
    private readonly ILogger<CursoController> _logger;
    private readonly ICursoService _service;

    public CursoController(ILogger<CursoController> logger, ICursoService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet("{idCurso}")]
    public async Task<ActionResult<ObtemCursoResponse>> ConsultarCursoAsync([FromRoute] int idCurso)
    {
        return Ok(_service.GetById(idCurso));
    }
}
