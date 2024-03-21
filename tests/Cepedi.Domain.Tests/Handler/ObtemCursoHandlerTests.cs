using Cepedi.Domain.Entities;
using Cepedi.Domain.Handlers;
using Cepedi.Domain.Repository;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using NSubstitute;
using Moq;

namespace Cepedi.Domain.Tests;

public class ObtemCursoHandlerTests
{
    private readonly ICursoRepository _cursoRepository = Substitute.For<ICursoRepository>();
    private readonly IProfessorRepository _professorRepository = Substitute.For<IProfessorRepository>();
    private readonly ObtemCursoHandler _sut;
    public ObtemCursoHandlerTests()
    {
        _sut = new ObtemCursoHandler(_cursoRepository, _professorRepository);
    }

    [Fact]
    public async Task ObtemCursoAsync_QuandoConsultado_DeveRetornarSucesso()
    {
        // Arrange
        _cursoRepository.ObtemCursoPorIdAsync(1).ReturnsForAnyArgs(new CursoEntity(1, "Nome", "descricao", DateTime.Now, DateTime.Now, new ProfessorEntity()));
        _professorRepository.ObtemProfessorPorIdAsync(1).ReturnsForAnyArgs(new ProfessorEntity(1, "Nome", "Especialidade"));

        // Act
        var result = await _sut.ObterCursoAsync(1);

        // Assert
        Assert.Equal(result, new ObtemCursoResponse("Nome", $"O curso tem duração de {DateTime.Now} até {DateTime.Now}", "Nome"));
    }
}
