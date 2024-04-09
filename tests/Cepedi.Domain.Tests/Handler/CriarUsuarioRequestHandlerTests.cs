using Cepedi.BancoCentral.Domain.Entities;
using Cepedi.BancoCentral.Domain.Handlers;
using Cepedi.BancoCentral.Domain.Repository;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using NSubstitute;

namespace Cepedi.BancoCentral.Domain.Tests;

public class CriarUsuarioRequestHandlerTests
{
    private readonly IUsuarioRepository _usuarioRepository =
    Substitute.For<IUsuarioRepository>();
    private readonly ILogger<CriarUsuarioRequestHandler> _logger = Substitute.For<ILogger<CriarUsuarioRequestHandler>>();
    private readonly CriarUsuarioRequestHandler _sut;

    public CriarUsuarioRequestHandlerTests()
    {
        _sut = new CriarUsuarioRequestHandler(_usuarioRepository, _logger);
    }

    [Fact]
    public async Task CriarUsuarioAsync_QuandoCriar_DeveRetornarSucesso()
    {
        //Arrange 
        var usuario = new CriarUsuarioRequest { Nome= "Denis" };
        _usuarioRepository.CriarUsuarioAsync(It.IsAny<UsuarioEntity>())
            .ReturnsForAnyArgs(new UsuarioEntity());

        //Act
        var result = await _sut.Handle(usuario, CancellationToken.None);

        //Assert 
        result.Should().BeOfType<CriarUsuarioResponse>().Which
            .nome.Should().Be(usuario.Nome);
        result.Should().BeOfType<CriarUsuarioResponse>().Which
            .nome.Should().NotBeEmpty();
    }

}
