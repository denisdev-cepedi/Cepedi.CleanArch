using Cepedi.Banco.Pessoa.Compartilhado.Requests;
using Cepedi.Banco.Pessoa.Compartilhado.Responses;
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

    [HttpGet]
    public async Task<ActionResult<ObterTodosEnderecosResponse>> ObterTodosEnderecos()
    {
        return await SendCommand(new ObterTodosEnderecosRequest());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ObterEnderecoResponse>> ObterEndereco([FromRoute] int id)
    {
        return await SendCommand(new ObterEnderecoRequest() { EnderecoId = id });
    }

    [HttpPost]
    public async Task<ActionResult<CadastrarEnderecoResponse>> CadastrarEndereco([FromBody] CadastrarEnderecoRequest request)
    {
        return await SendCommand(request);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<AtualizarEnderecoResponse>> AtualizarEndereco([FromBody] AtualizarEnderecoRequest request)
    {
        return await SendCommand(request);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ExcluirEnderecoResponse>> ExcluirEndereco([FromRoute] ExcluirEnderecoRequest request)
    {
        return await SendCommand(request);
    }

}
