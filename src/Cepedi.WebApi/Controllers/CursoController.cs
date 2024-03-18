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
}
