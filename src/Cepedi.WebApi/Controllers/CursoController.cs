using Cepedi.Data;
using Cepedi.Shareable.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CursoController : ControllerBase
{
    private readonly ILogger<CursoController> _logger;
    private readonly ApplicationDbContext _context;

    public CursoController(ILogger<CursoController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("{idCurso}")]
    public async Task<ActionResult<ObtemCursoResponse>> ConsultarCursoAsync([FromRoute] int idCurso)
    {
        var curso = await _context.Curso
            .FirstOrDefaultAsync(c => c.Id == idCurso);

        // tentei enviar um response, mas não consegui
        // if (curso == null)
        // {
        //     return NotFound();
        // }
        // ObtemCursoResponse response = new ObtemCursoResponse(curso.Nome, "curso.Horario", curso.Professor.Nome);
        // return Ok(response);
         return Ok(curso);
    }
}
