//using Cepedi.Banco.Pessoa.Dominio.Entidades;
//using Cepedi.Banco.Pessoa.Dominio.Handlers;
//using Cepedi.Banco.Pessoa.Dominio.Repository;
//using Cepedi.Compartilhado.Requests;
//using Cepedi.Compartilhado.Responses;
//using FluentAssertions;
//using Microsoft.Extensions.Logging;
//using Moq;
//using NSubstitute;
//using OperationResult;

//namespace Cepedi.Banco.Pessoa.Domain.Tests;

//public class CriarUsuarioRequestHandlerTests
//{
//    private readonly IUsuarioRepository _usuarioRepository =
//    Substitute.For<IUsuarioRepository>();
//    private readonly ILogger<CriarUsuarioRequestHandler> _logger = Substitute.For<ILogger<CriarUsuarioRequestHandler>>();
//    private readonly CriarUsuarioRequestHandler _sut;

//    public CriarUsuarioRequestHandlerTests()
//    {
//        _sut = new CriarUsuarioRequestHandler(_usuarioRepository, _logger);
//    }

//    [Fact]
//    public async Task CriarUsuarioAsync_QuandoCriar_DeveRetornarSucesso()
//    {
//        //Arrange 
//        var usuario = new CriarUsuarioRequest { Nome= "Denis" };
//        _usuarioRepository.CriarUsuarioAsync(It.IsAny<UsuarioEntity>())
//            .ReturnsForAnyArgs(new UsuarioEntity());

//        //Act
//        var result = await _sut.Handle(usuario, CancellationToken.None);

//        //Assert 
//        result.Should().BeOfType<Result<CriarUsuarioResponse>>().Which
//            .Value.nome.Should().Be(usuario.Nome);
//        result.Should().BeOfType<Result<CriarUsuarioResponse>>().Which
//            .Value.nome.Should().NotBeEmpty();
//    }

//}
