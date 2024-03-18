using Cepedi.Data.Repositories.Interfaces;
using Cepedi.Shareable.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Cepedi.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CursoController : ControllerBase
{
    private readonly ILogger<CursoController> _logger;
    private readonly ICursoRepository _cursoRepository;

    public CursoController(ILogger<CursoController> logger, ICursoRepository cursoRepository)
    {
        _logger = logger;
        _cursoRepository = cursoRepository;
    }

    [HttpGet("{idCurso}")]
    public async Task<ActionResult<ObtemCursoResponse>> ConsultarCursoAsync([FromRoute] int idCurso)
    {
        return Ok();
    }
}
