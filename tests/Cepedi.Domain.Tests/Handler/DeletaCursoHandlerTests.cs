using Cepedi.Domain.Entities;
using Cepedi.Domain.Handlers;
using Cepedi.Domain.Repository;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using NSubstitute;
using Moq;

namespace Cepedi.Domain.Tests;

public class DeletaCursoHandlerTests
{
    private readonly ICursoRepository _cursoRepository = Substitute.For<ICursoRepository>();
    private readonly DeletaCursoHandler _sut;
    public DeletaCursoHandlerTests()
    {
        _sut = new DeletaCursoHandler(_cursoRepository);
    }

    [Fact]
    public async Task ObtemCursoAsync_QuandoConsultado_DeveRetornarSucesso()
    {
        // Arrange
        _cursoRepository.DeletaCursoAsync(1).ReturnsForAnyArgs(1);

        // Act
        var result = await _sut.DeletaCursoAsync(1);

        // Assert
        Assert.Equal(result, new DeletaCursoResponse(1));
    }
}
