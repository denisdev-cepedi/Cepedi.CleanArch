using Cepedi.Domain.Entities;
using Cepedi.Domain.Handlers;
using Cepedi.Domain.Repository;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using NSubstitute;
using Moq;

namespace Cepedi.Domain.Tests;

public class CadastraCursoHandlerTests
{
    private readonly ICursoRepository _cursoRepository = Substitute.For<ICursoRepository>();
    // private readonly Mock<ICursoRepository> _cursoRepository = new Mock<ICursoRepository>();
    private readonly CadastraCursoHandler _sut;
    public CadastraCursoHandlerTests()
    {
        _sut = new CadastraCursoHandler(_cursoRepository);
    }

    [Fact]
    public async Task CriarCursoAsync_QuandoCriado_DeveRetornarSucesso()
    {
        // Arrange
        var curso = new CadastraCursoRequest(
            "Teste",
            "Teste",
            DateTime.Now,
            DateTime.Now,
            1
        );

        // Act
        _cursoRepository.CadastraCursoAsync(curso).ReturnsForAnyArgs(new CursoEntity(1, "Nome", "descricao", DateTime.Now, DateTime.Now, new ProfessorEntity()));
        // _cursoRepository.Setup(d => d.CadastraCursoAsync(curso)).ReturnsAsync(new CursoEntity(1, "Nome", "descricao", DateTime.Now, DateTime.Now, new ProfessorEntity()));
        var result = await _sut.CadastraCursoAsync(curso);

        // Assert
        Assert.Equal(result, new CadastraCursoResponse(1));
    }
}
