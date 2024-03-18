using Cepedi.Domain.Entities;
using Cepedi.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Cepedi.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CursoController : ControllerBase
{
    private readonly ILogger<CursoController> _logger;
    private readonly ICursoRepository _repository;

    public CursoController(ILogger<CursoController> logger, ICursoRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<ICollection<ProfessorEntity>>> ConsultarCursosAsync()
    {
        var cursos = _repository.GetAll();
        return Ok(cursos);
    }
    [HttpPost]
    public async Task<ActionResult> CriarProfessorAsync()
    {
        // _repository.Insert(model);
        return Ok();
    }
}
