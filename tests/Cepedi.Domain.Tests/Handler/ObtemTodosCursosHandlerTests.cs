using Cepedi.Domain.Entities;
using Cepedi.Domain.Handlers;
using Cepedi.Domain.Repository;
using Cepedi.Shareable.Responses;
using NSubstitute;

namespace Cepedi.Domain.Tests;

public class ObtemTodosCursosHandlerTests
{
    private readonly ICursoRepository _cursoRepository = Substitute.For<ICursoRepository>();
    private readonly IProfessorRepository _professorRepository = Substitute.For<IProfessorRepository>();
    private readonly ObtemTodosCursosHandler _sut;
    public ObtemTodosCursosHandlerTests()
    {
        _sut = new ObtemTodosCursosHandler(_cursoRepository, _professorRepository);
    }

    [Fact]
    public async Task ObtemTodosCursosAsync_QuandoConsultado_DeveRetornarSucesso()
    {
        // Arrange
        _cursoRepository.ObtemTodosCursosAsync().ReturnsForAnyArgs(new List<CursoEntity>());
        _professorRepository.ObtemProfessorPorIdAsync(1).ReturnsForAnyArgs(new ProfessorEntity());

        // Act
        var result = await _sut.ObterTodosCursosAsync();

        // Assert
        Assert.Equal(result.Cursos, new ObtemTodosCursosResponse(new List<ObtemCursoResponse>()).Cursos);
    }
}
