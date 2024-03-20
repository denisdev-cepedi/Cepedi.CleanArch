using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
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
        return Ok();
    }

    [HttpPost("criar")]
    public async Task<ActionResult<CadastraCursoResponse>> CadastrarCursoAsync([FromBody] CadastraCursoRequest request)
    {
        return Ok(new CadastraCursoResponse(request.curso, request.horario, request.professor));
    }

    [HttpGet("cursos")]
    public async Task<ActionResult<IEnumerable<ObtemCursoResponse>>> ListarCursosAsync()
    {
        return Ok();
    }

    [HttpPut("{idCurso}")]
    public async Task<ActionResult<AtualizaCursoResponse>> AtualizarCursoAsync([FromRoute] int idCurso, [FromBody] AtualizaCursoRequest request)
    {
        return Ok(new AtualizaCursoResponse(request.curso, request.horario, request.professor));
    }
}
