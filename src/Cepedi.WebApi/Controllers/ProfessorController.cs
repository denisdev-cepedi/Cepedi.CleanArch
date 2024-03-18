using Cepedi.Domain.Entities;
using Cepedi.Domain.Repository;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Cepedi.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProfessorController : ControllerBase
{
    private readonly ILogger<ProfessorController> _logger;
    private readonly IProfessorRepository _repository;

    public ProfessorController(ILogger<ProfessorController> logger, IProfessorRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<ICollection<ProfessorEntity>>> ConsultarProfessorAsync()
    {
        var professores = _repository.GetAll();
        return Ok(professores);
    }
    [HttpPost]
    public async Task<ActionResult> CriarProfessorAsync(ProfessorRequest model)
    {
        // _repository.Insert(model);
        return Ok();
    }
}
