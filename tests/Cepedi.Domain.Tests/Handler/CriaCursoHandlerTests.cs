using Cepedi.Data;
using Cepedi.Domain.Entities;
using Cepedi.Domain.Handlers;
using Cepedi.Shareable.Requests;
using Microsoft.EntityFrameworkCore;
using NSubstitute;

namespace Cepedi.Domain.Tests;

public class CriaCursoHandlerTests
{
    private readonly ICursoRepository _cursoRepository = 
    Substitute.For<ICursoRepository>();
    private readonly IWhatsApp _whatsApp = Substitute.For<IWhatsApp>();
    private readonly CriaCursoHandler _sut;

    public CriaCursoHandlerTests()
    {
        _sut = new CriaCursoHandler(_cursoRepository, _whatsApp);
    }

    //TODO : Devo fazer esse teste em algum momento na minha vida
    // [Fact]
    // public async Task CriarCursoAsync_QuandoCriadoEnviarWhatsApp_DeveLancarException()
    // {
    //     // Arrange
    //     var curso = new CriaCursoRequest
    //     ("Teste", "Descricao", DateTime.Now,
    //      DateTime.Now,1 );

    //     // Act
    //     var result = await _sut.CriarCursoAsync(curso);

    //     // Assert 
    //     Assert.Equal(result, default(int));
    // }

    [Fact]
    public async Task CriarCursoAsync_QuandoCriadoEnviarWhatsApp_DeveRetornarSucesso()
    {
        // Arrange
        var curso = new CriaCursoRequest
        ("Teste", "Descricao", DateTime.Now,
         DateTime.Now,1, "71123456");

         _whatsApp.EnviarMensagemWhatsAppAsync(
            default(string), default(string))
         .ReturnsForAnyArgs("Sucesso");

        // Act
        var result = await _sut.CriarCursoAsync(curso);

        // Assert 
        Assert.Equal(result, default(int));
    }

}