using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cepedi.Banco.Pessoa.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EnderecoController : BaseController
{
    private readonly ILogger<EnderecoController> _logger;

    public EnderecoController(IMediator mediator, ILogger<EnderecoController> logger) : base(mediator)
    {
        _logger = logger;
    }
}
