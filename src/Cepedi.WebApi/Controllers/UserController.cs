using Cepedi.BancoCentral.Domain;
using Cepedi.BancoCentral.Domain.Repository;
using Cepedi.Shareable.Exceptions;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cepedi.BancoCentral.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IMediator _mediator;

    public UserController(
        ILogger<UserController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    //[HttpGet("{idUsuario}")]
    //public async Task<ActionResult<CriarUsuarioResponse>> ObterUsuarioAsync([FromRoute] int idUsuario)
    //{
    //    return await _mediator.Send(new CriarUsuarioRequest();
    //}
    
    //[HttpGet()]
    //public async Task<ActionResult<IEnumerable<CriarUsuarioResponse>>> ConsultarCursosAsync()
    //{
    //    return Ok(await _obtemCursoHandler.ObterCursosAsync());
    //}
    
    [HttpPost]
    [ProducesResponseType(typeof(CriarUsuarioResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CriarUsuarioResponse>> CriarCursoAsync([FromBody] CriarUsuarioRequest request)
    {
        return await _mediator.Send(request);
    }

    //[HttpPut]
    //public async Task<ActionResult<int>> AlterarCursoAsync([FromBody] CriarUsuarioRequest request)
    //{
    //    var cursoId = await _alteraCursoHandler.AlterarCursoAsync(request);
    //    return Ok(cursoId);
    //}
}
