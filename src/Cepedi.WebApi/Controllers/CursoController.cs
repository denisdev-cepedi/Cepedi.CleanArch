using Cepedi.Data;
using Cepedi.Domain;
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
    private readonly ApplicationDbContext _context;
    public CursoController(ILogger<CursoController> logger,
    IObtemCursoHandler obtemCursoHandler,
    ICreateCursoHandler createCursoHandler)
    {
        _logger = logger;
        _obtemCursoHandler = obtemCursoHandler;
        _createCursoHandler = createCursoHandler;
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
}
