using Cepedi.BancoCentral.Domain.Repository;
using Cepedi.Domain.Handlers;
using Cepedi.Shareable.Requests;
using NSubstitute;

namespace Cepedi.Domain.Tests;

public class AlterarCursoHandlerTests
{
    private readonly IUsuarioRepository _userRepository = 
    Substitute.For<IUsuarioRepository>();
    private readonly AlterarUsuarioRequestHandler _sut;

    public AlterarCursoHandlerTests()
    {
        _sut = new AlterarUsuarioRequestHandler(_userRepository);
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
    public async Task AlterarUserAsync_QuandoAlteradoUser_DeveRetornarSucesso()
    {
        // Arrange
        var curso = new AlterarUsuarioRequest
        ("Teste", "Descricao", DateTime.Now,
         DateTime.Now,1, 71, "teste");



        // Act
        var result = await _sut.Handle(curso, new CancellationToken());

        // Assert 
        // Assert.Equal(result, default( new {}));
    }

}
